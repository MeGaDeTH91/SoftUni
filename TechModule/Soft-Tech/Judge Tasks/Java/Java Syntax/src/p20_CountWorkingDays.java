import java.time.DayOfWeek;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Arrays;
import java.util.Scanner;

class p20_CountWorkingDays {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String dateOne = scanner.nextLine();
        String dateTwo = scanner.nextLine();

        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd-MM-yyyy");

        LocalDate startDate = LocalDate.from(formatter.parse(dateOne));
        LocalDate endDate = LocalDate.from(formatter.parse(dateTwo));

        LocalDate[] officialHolidays = new LocalDate[]{
                LocalDate.of(2016, 1, 1),
                LocalDate.of(2016, 3, 3),
                LocalDate.of(2016, 5, 1),
                LocalDate.of(2016, 5, 6),
                LocalDate.of(2016, 5, 24),
                LocalDate.of(2016, 9, 6),
                LocalDate.of(2016, 9, 22),
                LocalDate.of(2016, 11, 1),
                LocalDate.of(2016, 12, 24),
                LocalDate.of(2016, 12, 25),
                LocalDate.of(2016, 12, 26)
        };

        int workingDaysCounter = 0;

        for (LocalDate date = startDate; date.isBefore(endDate.plusDays(1)); date = date.plusDays(1)) {
            LocalDate currentDate = LocalDate.of(2016, date.getMonth(), date.getDayOfMonth());

            if (!Arrays.asList(officialHolidays).contains(currentDate) &&
                    date.getDayOfWeek() != DayOfWeek.SATURDAY &&
                    date.getDayOfWeek() != DayOfWeek.SUNDAY) {
                workingDaysCounter++;
            }
        }
        System.out.println(workingDaysCounter);
    }
}