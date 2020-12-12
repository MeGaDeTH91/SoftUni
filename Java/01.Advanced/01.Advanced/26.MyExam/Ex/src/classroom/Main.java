package classroom;

public class Main {
	public static void main(String[] args){
		// Initialize the repository
		Classroom classroom = new Classroom(10);
// Initialize entities
		Student student = new Student("Peter", "Parker", "Geometry");
		Student studentTwo = new Student("Sarah", "Smith", "Algebra");
		Student studentThree = new Student("Sam", "Winchester", "Algebra");
		Student studentFour = new Student("Dean", "Winchester", "Music");
		Student studentFive = new Student("Ellie", "Goulding", "Music");
// Print Student
		System.out.println(student);
		// Student: First Name = Peter, Last Name = Parker, Subject = Geometry
// Register Student
		String register = classroom.registerStudent(student);
		System.out.println(register); // Added student Peter Parker
		String registerTwo = classroom.registerStudent(studentTwo);
		String registerThree = classroom.registerStudent(studentThree);
		String registerFour = classroom.registerStudent(studentFour);
// Dismiss Student
		String dismissed = classroom.dismissStudent(student);
		System.out.println(dismissed); // Removed student Peter Parker
		String dismissedTwo = classroom.dismissStudent(studentFive);
		System.out.println(dismissedTwo); // Student not found
// Subject info
		String subjectInfo = classroom.getSubjectInfo("Algebra");
		System.out.println(subjectInfo);
// Subject: Algebra
// Students:
// Sarah Smith
// Sam Winchester
		String anotherInfo = classroom.getSubjectInfo("Art");
		System.out.println(anotherInfo); // No students enrolled for the subject
// Get Student
		System.out.println(classroom.getStudent("Dean", "Winchester"));
		System.out.println(classroom.getStatistics());
// Student: First Name = Dean, Last Name = Winchester, Subject = Music
	}
}
