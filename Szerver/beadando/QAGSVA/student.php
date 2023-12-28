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
        $username = $_GET['username'];
        echo json_encode(
            array(
                'error' => 0,
                'message' => 'Sikeres lekérdezés!',
                'lessons' => getLessons($username)
            )
        );
        break;
    case "POST":
        $instructor = filter_var($_POST["instructor"], FILTER_SANITIZE_STRING);
        $username = filter_var($_POST["username"], FILTER_SANITIZE_STRING);
        $distance = filter_var($_POST["distance"], FILTER_SANITIZE_STRING);
        $hours = filter_var($_POST["hours"], FILTER_SANITIZE_STRING);
        $description = filter_var($_POST["description"], FILTER_SANITIZE_STRING);
        $date = filter_var($_POST["date"], FILTER_SANITIZE_STRING);
        if ($date > date("Y-m-d")) {
            echo json_encode(
                array(
                    'error' => 4,
                    'message' => "Előre nem lehet órát felvenni!"
                )
            );

        } else {
            if (!empty($username) && !empty($distance) && !empty($hours) && !empty($date)){
                if(userExists($username)){
                    if(ownStudent($username, $instructor)){
                        if(preg_match('/^\d+$/', $distance) && preg_match('/^\d+$/', $hours)){
                            if(empty($description)){
                                addLesson($username, $distance,$hours,"",$date);
                                echo json_encode(
                                    array(
                                        'error' => 0,
                                        'message' => "Óra sikeresen felvéve! (Közúti közlekedés)"
                                    )
                                );
                            } else{
                                if ($description == "Forgalmi vizsga"){
                                    echo json_encode(
                                        array(
                                            'error' => 99,
                                            'message' => "Forgalmi vizsga felvételéhez használja a megfelelő gombot!"
                                        )
                                    );
                                } else {
                                    addLesson($username, $distance,$hours,$description,$date);
                                    echo json_encode(
                                        array(
                                            'error' => 0,
                                            'message' => "Óra sikeresen felvéve! ($description)"
                                        )
                                    );
                                }
                            }
                        } else {
                            echo json_encode(
                                array(
                                    'error' => 3,
                                    'message' => "Kérem a távolságot vagy időt számmal adja meg!"
                                )
                            );
                        }
                    } else {
                        echo json_encode(
                            array(
                                'error' => 4,
                                'message' => "Kérem saját tanulót adjon meg!"
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
                        'message' => "Kérem töltsön ki minden szükséges mezőt!"
                    )
                );
            }
        }

    

        break;
    case "PUT":
        $content = file_get_contents('php://input');
        $data = json_decode($content, true);
        $instructor = filter_var($data['instructor'], FILTER_SANITIZE_STRING);
        $id = filter_var($data['id'], FILTER_SANITIZE_STRING);
        $studentname = filter_var($data['student_name'], FILTER_SANITIZE_STRING);
        $distance = filter_var($data['distance'], FILTER_SANITIZE_STRING);
        $hours = filter_var($data['hours'], FILTER_SANITIZE_STRING);
        $description = filter_var($data['description'], FILTER_SANITIZE_STRING);
        $date = filter_var($data['date'], FILTER_SANITIZE_STRING);
        if(!empty($id)){
            if(lessonExists($id)){
                if(ownStudent($studentname, $instructor)){
                    updateLesson($id, $studentname, $distance, $hours, $description, $date);
                } else {
                    echo json_encode(
                        array(
                            'error' => 3,
                            'message' => "Csak saját órát tud módosítani!"
                        )
                    );
                }
                
            } else {
                echo json_encode(
                    array(
                        'error' => 2,
                        'message' => "Nem létezik ilyen ID-val vezetési óra!"
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
    case "DELETE":
        $content = file_get_contents('php://input');
        $data = json_decode($content, true);
        $instructor = filter_var($data['instructor'], FILTER_SANITIZE_STRING);
        $id = filter_var($data['id'], FILTER_SANITIZE_STRING);
        $studentname = filter_var($data['studentname'], FILTER_SANITIZE_STRING);
        if(lessonExists($id)){
            if(ownStudent($studentname,$instructor)){
                if(!isTest($id)){
                    if (!hasTest($studentname)){
                        deleteLesson($id, $studentname);
                    echo json_encode(
                        array(
                            'error' => 0,
                            'message' => "Óra sikeresen törölve!"
                        )
                    );
                    } else {
                        echo json_encode(
                            array(
                                'error' => 4,
                                'message' => "Vizsga után már nem lehet törölni órát!"
                            )
                        );
                    }
                } else{
                    echo json_encode(
                        array(
                            'error' => 3,
                            'message' => "Vizsgát nem lehet törölni!"
                        )
                    );
                }
                
            } else{
                echo json_encode(
                    array(
                        'error' => 2,
                        'message' => "Csak saját órát tud törölni!"
                    )
                );
            }
            
        } else {
            echo json_encode(
                array(
                    'error' => 1,
                    'message' => "Nem létezik ilyen ID-val óra!"
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


function addLesson($username, $distance, $hours, $description, $date){
    global $connect;
    if(empty($description)){
        $result = $connect -> query("INSERT INTO drive (student_name, distance, hours, date) VALUES ('$username', '$distance', '$hours', '$date');"); 
    } else {
        $result = $connect -> query("INSERT INTO drive (student_name, distance, hours, description, date) VALUES ('$username', '$distance', '$hours', '$description', '$date');"); 
    }

}
function hasTest($student){
    global $connect;

    $result = count($connect -> query("SELECT * FROM drive WHERE student_name = '$student' AND description = 'Forgalmi vizsga';")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}
function isTest($id){
    global $connect;

    $result = count($connect -> query("SELECT * FROM drive WHERE id = '$id' AND description = 'Forgalmi vizsga';")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}

function deleteLesson($id, $studentname){
    global $connect;

    $connect -> query("DELETE FROM drive WHERE ID = '$id' AND student_name = '$studentname';");
}

function updateLesson($id, $username, $distance, $hours, $description, $date){
    global $connect;

    if(!empty($username)){
        if(!userExists($username)){
            echo json_encode(
                array(
                    'error' => 3,
                    'message' => "Nincs ilyen nevű tanuló!"
                )
            );
            return;
        }
        $connect -> query("UPDATE drive SET student_name = '$username' WHERE id = '$id';");
    }

    if(!empty($distance)){
        if(!preg_match('/^\d+$/', $distance)){
            echo json_encode(
                array(
                    'error' => 4,
                    'message' => "Nem megfelelő távolság"
                )
            );
            return;
        }
        $connect -> query("UPDATE drive SET distance = '$distance' WHERE id = '$id';");
    }

    if(!empty($hours)){
        if(!preg_match('/^\d+$/', $hours)){
            echo json_encode(
                array(
                    'error' => 5,
                    'message' => "Nem megfelelő idó!"
                )
            );
            return;
        }
        $connect -> query("UPDATE drive SET hours = '$hours' WHERE id = '$id';");
    }
    if(!empty($description)){
        $connect -> query("UPDATE drive SET description = '$description' WHERE id = '$id';");
    }
    if(!empty($date)){
        $connect -> query("UPDATE drive SET date = '$date' WHERE id = '$id';");
    }
    echo json_encode(
        array(
            'error' => 0,
            'message' => "Óra sikeresen módosítva!"
        )
    );
}


function getLessons($username){
    global $connect;
    if(empty($username)){
        $result = $connect -> query("SELECT * FROM drive;");
        return $result -> fetch_all(MYSQLI_ASSOC);
    }

    $result = $connect -> query("SELECT * FROM drive WHERE student_name = '$username';");
    return $result -> fetch_all(MYSQLI_ASSOC);
}

function userExists($username){
    global $connect;

    $result = count($connect -> query("SELECT * FROM users WHERE username = '$username' AND role = 'STUDENT';")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}

function ownStudent($studentname, $instuctorname){
    global $connect;

    $result = count($connect -> query("SELECT * FROM student_instructor WHERE student = '$studentname' AND instructor = '$instuctorname';")->fetch_all(MYSQLI_ASSOC));
    return $result > 0;
}

function lessonExists($id){
    global $connect;

    $result = count($connect -> query("SELECT * FROM drive WHERE id = '$id'")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}

?>