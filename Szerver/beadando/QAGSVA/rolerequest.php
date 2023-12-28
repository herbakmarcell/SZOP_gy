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
        $password = filter_var($_GET["password"], FILTER_SANITIZE_STRING);
        $currentuser = $_GET["currentuser"];
        $currentpassword = $_GET["currentpassword"];
        $roleArray = userRole($username, $password);
        if(!empty($username) && !empty($password)){
            if(userExists($username, $password)){
                if ($username == $currentuser && $password == $currentpassword){
                    echo $roleArray[0];
                }
                else{
                    echo "Légyszi ne bántsd a Postman-t!";
                }
            }
        }
        break;
    default:
        echo "Nem megfelelő role!";
    break;
}

function userExists($username, $password){
    global $connect;

    $result = count($connect -> query("SELECT * FROM users WHERE username = '$username' AND password = md5('$password');")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}

function userRole($username, $password){
    global $connect;

    $result = $connect -> query("SELECT role FROM users WHERE username = '$username' AND password = md5('$password') LIMIT 1;")->fetch_row();
    return $result;
}

?>