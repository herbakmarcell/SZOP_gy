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
                $instructorArray = getInstructorName($username);
                if ($instructorArray[0] != "Nincs még"){
                    $fullName = getInstructorFullName($instructorArray[0]);  
                    echo $fullName[0]; 
                } else{
                    echo $instructorArray[0];   
                }
                            
            }
        }
        break;
    case "POST":
        $student = $_GET["student"];
        if(!empty($student)){
            addStudent($student);
        } else{
            echo "Üres!";
        }
        break;
    case "PUT":
        
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

function getInstructorName($username){
    global $connect;

    $result = $connect -> query("SELECT IFNULL(instructor,'Nincs még') FROM student_instructor WHERE student = '$username';")->fetch_row();
    return $result;
}
function getInstructorFullName($instructorName){
    global $connect;

    $result = $connect -> query("SELECT name FROM users WHERE username = '$instructorName';")->fetch_row();
    return $result;
}
function addStudent($studentName){
    global $connect;

    $result = $connect -> query("INSERT INTO student_instructor (student) VALUES ('$studentName');"); 

}

?>