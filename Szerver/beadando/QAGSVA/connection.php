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
    case 'GET':
        try {
            if ($connect){
                echo json_encode(
                    array(
                        'error' => 0,
                        'message' => 'Sikeres csatlakozás!'
                    )
                );
            } else {
                echo json_encode(
                    array(
                        'error' => 1,
                        'message' => 'Sikertelen csatlakozás!'
                    )
                );
            }
        } catch (Exception $e) {
            echo json_encode(
                array(
                    'error' => 1,
                    'message' => 'Sikertelen csatlakozás!'
                )
            );
        }
        break;
    default:
        break;
}

?>