<?php
include("./database.php");

$userAgent = $_SERVER['HTTP_USER_AGENT'];

if (strpos($userAgent, 'RestSharp') !== false) {

} else {
    header('HTTP/1.0 403 Forbidden');
    echo "Hozzáférés megtagadva. Kérjük használja autósiskolánk szoftverét!";
    exit();
}

$request = $_SERVER['REQUEST_METHOD'];

switch($request){

    case "GET":
        $username = filter_var($_GET["username"], FILTER_SANITIZE_STRING);
        if(!empty($username)){
            if(userExists($username)){
                $distanceArray = allKM($username);
                echo $distanceArray[0];
            }
        }
        break;
    default:
        echo "Nem megfelelő!";
    break;
}

function userExists($username){
    global $connect;

    $result = count($connect -> query("SELECT * FROM users WHERE username = '$username';")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}

function allKM($username){
    global $connect;

    $result = $connect -> query("SELECT IFNULL(sum(distance),0) FROM drive WHERE student_name = '$username';")->fetch_row();
    return $result;
}

?>