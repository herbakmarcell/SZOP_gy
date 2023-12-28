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
        echo json_encode(
            array(
                'error' => 0,
                'message' => "Sikeres lekérdezés",
                'students' => getAloneStudents()
            )
        );
        break;
    case 'PUT':
        $content = file_get_contents('php://input');
        $data = json_decode($content, true);

        $instructor = filter_var($data['instructor'], FILTER_SANITIZE_STRING);
        $student = filter_var($data['student'], FILTER_SANITIZE_STRING);

        if(!empty($instructor) && !empty($student)){
            if(userExists($student)){
                if(isAlone($student)){
                    updateInstructor($student, $instructor);
                    addFirstLesson($student, $instructor);
                    echo json_encode(
                        array(
                            'error' => 0,
                            'message' => "Tanuló sikeresen felvéve!",
                        )
                    );
                } else {
                    echo json_encode(
                        array(
                            'error' => 3,
                            'message' => "A tanulónak már van oktatója!",
                        )
                    );
                }
            } else {
                echo json_encode(
                    array(
                        'error' => 2,
                        'message' => "Nincs ilyen tanuló!",
                    )
                );
            }
        } else {
            echo json_encode(
                array(
                    'error' => 1,
                    'message' => "Hibás paraméterek!",
                )
            );
        }
        break;
    default:
        break;
}
function addFirstLesson($student, $instructor){
    global $connect;

    $connect -> query("INSERT INTO `drive`(`student_name`, `distance`, `hours`, `description`, `date`) VALUES ('$student',0,0,'Tanuló felvéve ($instructor)',DATE_FORMAT(CURDATE(), '%Y-%m-%d'));");

}
function updateInstructor($student, $instructor){
    global $connect;

    $connect -> query("UPDATE student_instructor SET instructor = '$instructor' WHERE student = '$student';");
    
}
function getAloneStudents(){
    global $connect;
    
    $result = $connect -> query("SELECT student, instructor FROM student_instructor WHERE instructor IS NULL;")->fetch_all(MYSQLI_ASSOC);
    return $result;
}
function isAlone($student){
    global $connect;

    $result = count($connect -> query("SELECT student, instructor FROM student_instructor WHERE student = '$student' AND instructor IS NULL;")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}
function userExists($username){
    global $connect;

    $result = count($connect -> query("SELECT * FROM users WHERE username = '$username' AND role = 'STUDENT';")->fetch_all(MYSQLI_ASSOC));

    return $result > 0;
}


?>