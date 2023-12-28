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
        if(!empty($username) && !empty($password)){
            if(userExists($username, $password)){
                echo json_encode(
                    array(
                        'error' => 0,
                        'message' => "Sikeres bejelentkezés!"
                    )
                );
            }
            else{
                echo json_encode(
                    array(
                        'error' => 1,
                        'message' => "Felhasználó nem található!"
                    )
                );
            }
        }
        else{
            echo json_encode(
                array(
                    'error' => 1,
                    'message' => "Hibás belépési információ!"
                )
            );
        }
        break;
    default:
        echo json_encode(
            array(
                'error' => -1,
                'message' => "Hibás kérés!"
            )
        );
    break;
}

function userExists($username, $password){
    global $connect;

    $result = count($connect -> query("SELECT * FROM users WHERE username = '$username' AND password = md5('$password');")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}
?>