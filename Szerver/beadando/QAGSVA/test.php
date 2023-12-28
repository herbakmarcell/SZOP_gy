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
    case 'GET':
        $username = $_GET['username'];
        echo json_encode(
            array(
                'error' => 0,
                'message' => 'Sikeres lekérdezés!',
                'tests' => getTests($username)
            )
        );
        break;
    case 'POST':
        $content = file_get_contents('php://input');
        $data = json_decode($content, true);
        $instructor = filter_var($data['instructor'], FILTER_SANITIZE_STRING);
        $studentname = filter_var($data['student_name'], FILTER_SANITIZE_STRING);
        $date = filter_var($data['date'], FILTER_SANITIZE_STRING);

        $dateTime = new DateTime();
        $currentDate = $dateTime->format("Y-m-d");

        if (date($date) <= $currentDate) {
            echo json_encode(
                array(
                    'error' => 1,
                    'message' => "Vizsgát nem lehet utólag felvenni!"
                )
            );
        } else {
            if (!empty($instructor) && !empty($studentname) && !empty($date)){
                if(userExists($studentname)){
                    if(ownStudent($studentname, $instructor)){
                        if(!hasOngoingTest($studentname)){
                            $hours = allHours($studentname);
                            $distance = allKM($studentname);
                            $hoursInt = intval($hours[0]);
                            $distanceInt = intval($distance[0]);

                            if($hoursInt >= 29){
                                if($distanceInt >= 580) {
                                    addTest($studentname, $instructor, $date);
                                    addTestLesson($studentname,$date);
                                    echo json_encode(
                                        array(
                                            'error' => 0,
                                            'message' => "Vizsga sikeresen felvéve!"
                                        )
                                    );
                                } else {
                                    echo json_encode(
                                        array(
                                            'error' => 5,
                                            'message' => "A tanulónak nincs meg a megfelelő megtett távolság ($distanceInt / 580)"
                                        )
                                    );
                                }
                            } else {
                                echo json_encode(
                                    array(
                                        'error' => 4,
                                        'message' => "A tanulónak nincs meg a megfelelő óraszám! ($hoursInt / 30)"
                                    )
                                );
                            }
                        } else {
                            echo json_encode(
                                array(
                                    'error' => 6,
                                    'message' => "A tanulónak már van egy nem értékelt vizsgája!"
                                )
                            );
                        }
                    } else {
                        echo json_encode(
                            array(
                                'error' => 3,
                                'message' => "Csak saját tanulót küldhet vizsgázni!"
                            )
                        );
                    }
                    
                    
                } else {
                    echo json_encode(
                        array(
                            'error' => 2,
                            'message' => "Nincs ilyen tanuló!"
                        )
                    );
                }
            } else {
                echo json_encode(
                    array(
                        'error' => 1,
                        'message' => "Kérem töltsön ki minden mezőt!"
                    )
                );
            }
        }
        break;
    case 'PUT':
        $content = file_get_contents('php://input');
        $data = json_decode($content, true);

        $invigilator = filter_var($data['invigilator'], FILTER_SANITIZE_STRING);
        $id = filter_var($data['id'], FILTER_SANITIZE_STRING);
        if(!empty($id)){
            if (testExists($id)){
                if(hasNotInvigilator($id)){
                    updateInvigilator($id,$invigilator);
                    echo json_encode(
                        array(
                            'error' => 0,
                            'message' => "Vizsga sikeresen felvéve vizsgabiztosként!"
                        )
                    );
                } else {
                    echo json_encode(
                        array(
                            'error' => 3,
                            'message' => "Ennek a vizsgának már van vizsgabiztosa!"
                        )
                    );
                }
            } else {
                echo json_encode(
                    array(
                        'error' => 2,
                        'message' => "Nem létezik ilyen vizsga!"
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

function getTests($username){
    global $connect;

    $result = $connect -> query("SELECT * FROM tests WHERE invigilator = '$username' OR invigilator = 'Kiválasztás alatt';");
    return $result -> fetch_all(MYSQLI_ASSOC);
}

function updateInvigilator($id, $invigilator){
    global $connect;

    $connect -> query("UPDATE tests SET invigilator = '$invigilator' WHERE id = '$id';");
}
function hasNotInvigilator($id){
    global $connect;

    $result = count($connect -> query("SELECT * FROM tests WHERE id = '$id' AND invigilator = 'Kiválasztás alatt';")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}
function addTest($studentname, $instuctorname, $date, ){
    global $connect;

    $result = $connect -> query("INSERT INTO tests (student, instructor, date) VALUES ('$studentname', '$instuctorname', '$date');"); 
}
function testExists($id){
    global $connect;

    $result = count($connect -> query("SELECT * FROM tests WHERE id = '$id'")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}
function userExists($username){
    global $connect;

    $result = count($connect -> query("SELECT * FROM users WHERE username = '$username' AND role = 'STUDENT';")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}
function addTestLesson($studentname,$date){
    global $connect;
    $result = $connect -> query("INSERT INTO drive (student_name, distance, hours, description, date) VALUES ('$studentname', 10, 1, 'Forgalmi vizsga', '$date');"); 
}

function hasOngoingTest($studentname){
    global $connect;

    $result = count($connect -> query("SELECT * FROM tests WHERE student = '$studentname' AND status = 'Még nincs értékelve';")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}
function ownStudent($studentname, $instuctorname){
    global $connect;

    $result = count($connect -> query("SELECT * FROM student_instructor WHERE student = '$studentname' AND instructor = '$instuctorname';")->fetch_all(MYSQLI_ASSOC));
    return $result > 0;
}

function allHours($username){
    global $connect;

    $result = $connect -> query("SELECT IFNULL(sum(hours),0) FROM drive WHERE student_name = '$username';")->fetch_row();
    return $result;
}

function allKM($username){
    global $connect;

    $result = $connect -> query("SELECT IFNULL(sum(distance),0) FROM drive WHERE student_name = '$username';")->fetch_row();
    return $result;
}

?>