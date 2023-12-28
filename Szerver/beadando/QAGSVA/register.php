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

switch ($request) {
    case 'POST':
        $username = filter_var($_POST["username"], FILTER_SANITIZE_STRING);
        $password = filter_var($_POST["password"], FILTER_SANITIZE_STRING);
        $name = filter_var($_POST["name"], FILTER_SANITIZE_STRING);
        if(!empty($username) && !empty($password) && !empty($name)){
            if(!userExists($username)){
                registerUser($username, $password, $name);
                addStudent($username);
                echo json_encode(
                    array(
                        'error' => 0,
                        'message' => "Regisztráció sikeres! Most már bejelentkezhet!"
                    )
                );
            }
            else{
                echo json_encode(
                    array(
                        'error' => 1,
                        'message' => "Ez a felhasználónév már foglalt!"
                    )
                );
            }
        }
        else{
            echo json_encode(
                array(
                    'error' => 2,
                    'message' => "Kérem töltse ki az összes mezőt!"
                )
            );
        }
        break;
    default:
        echo json_encode(
            array(
                'error' => -1,
                'message' => "Hibás kérés"
            )
        );
        break;
}

function registerUser($username, $password, $name){
    global $connect;

    $result = $connect -> query("INSERT INTO users (username, password, name, role) VALUES ('$username', MD5('$password'), '$name', 'STUDENT');");
}

function addStudent($username){
    global $connect;

    $connect -> query("INSERT INTO student_instructor (student) VALUES ('$username');");
}
function userExists($username){
    global $connect;

    $result = count($connect -> query("SELECT * FROM users WHERE username = '$username'")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}

?>