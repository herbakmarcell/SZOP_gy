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
    case 'PUT':
        $content = file_get_contents('php://input');
        $data = json_decode($content, true);

        $invigilator = filter_var($data['invigilator'], FILTER_SANITIZE_STRING);
        $id = filter_var($data['id'], FILTER_SANITIZE_STRING);
        $status = filter_var($data['status'], FILTER_SANITIZE_STRING);

        if(!empty($id)){
            if(isMyTest($id, $invigilator)){
                if(!empty($status)) {
                    if(isBeforeOrToday($id)){
                        if(!hasStatus($id)){
                            if($status == "Megfelelt" || $status == "Nem felelt meg" || $status == "Még nincs értékelve"){
                                updateStatus($id, $status);
                                echo json_encode(
                                    array(
                                        'error' => 0,
                                        'message' => "Vizsga sikeresen értékelve! ($status)"
                                    )
                                );
                            } else {
                                echo json_encode(
                                    array(
                                        'error' => 4,
                                        'message' => "Nem megfelelő értékelés!"
                                    )
                                );
                            }
                        } else {
                            echo json_encode(
                                array(
                                    'error' => 3,
                                    'message' => "A vizsga már értékelve van!"
                                )
                            );
                        }
                    } else {
                        echo json_encode(
                            array(
                                'error' => 2,
                                'message' => "Előre nem értékelhet vizsgát!"
                            )
                        );
                    }
                } else {
                    echo json_encode(
                        array(
                            'error' => 1,
                            'message' => "Kérem írja be az eredményt!"
                        )
                    );
                }
            } else {
                echo json_encode(
                    array(
                        'error' => 99,
                        'message' => "Csak saját tesztet tud értékelni!"
                    )
                );
            }
        } else {
            echo json_encode(
                array(
                    'error' => 1,
                    'message' => "Kérem adjon meg ID-t!"
                )
            );
        }
        break;
    default:
    echo json_encode(
        array(
            'error' => -1,
            'message' => "Nincs ilyen kérés!"
        )
    );
    break;
}
function isMyTest($id, $invigilator){
    global $connect;

    $result = count($connect -> query("SELECT * FROM tests WHERE id = '$id' AND invigilator = '$invigilator';")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}

function isBeforeOrToday($id){
    global $connect;

    $result = count($connect -> query("SELECT * FROM tests WHERE id = '$id' AND date <= DATE_FORMAT(CURDATE(), '%Y-%m-%d');")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}

function hasStatus($id){
    global $connect;

    $result = count($connect -> query("SELECT * FROM tests WHERE id = '$id' AND (status = 'Megfelelt' OR status = 'Nem felelt meg');")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}
function updateStatus($id, $status){
    global $connect;

    $connect -> query("UPDATE tests SET status = '$status' WHERE id = '$id';");
}
?>