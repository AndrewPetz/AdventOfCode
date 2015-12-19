package day5;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.function.Predicate;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class Day5 {

    public static void main(String[] args) {

        List<String> input = new ArrayList<>();

        try(Scanner inputScanner = new Scanner(new File("src/day5/input.txt"))) {

            while(inputScanner.hasNext()) {
                input.add(inputScanner.next());
            }

        }
        catch (FileNotFoundException ex) {
            System.out.println("File not found");
            return;
        }

        long timeBefore = System.nanoTime();

        List niceKidsModel1 = input.parallelStream().filter((String current) -> isNiceModel1(current)).collect(Collectors.toList());
        List niceKidsModel2 = input.parallelStream().filter((String current) -> isNiceModel2(current)).collect(Collectors.toList());;

        long runtime = System.nanoTime() - timeBefore;
        System.out.println("Number of nice Kids (model 1): " + niceKidsModel1.size());
        System.out.println("Number of nice Kids (model 2): " + niceKidsModel2.size());
        System.out.println("Runtime: " + runtime/1000 + "μs");

    }

    public static boolean isNiceModel1(String input) {

        Predicate<String> doesContainNaughtyStrings = (s -> s.contains("ab") ||
                s.contains("cd") ||
                s.contains("pq") ||
                s.contains("xy"));
        Predicate<String> doesNotContainNaughtyStrings = doesContainNaughtyStrings.negate();

        // Thanks to http://stackoverflow.com/questions/644714/what-regex-can-match-sequences-of-the-same-character
        final Pattern doubleCharRow = Pattern.compile("(.)\\1+");
        Predicate<String> containsDoubleCharRow = (s -> doubleCharRow.matcher(s).find());

        Predicate<String> contains3Vowels = (s -> numberOfVowels(s) >= 3);

        return contains3Vowels.and(containsDoubleCharRow).and(doesNotContainNaughtyStrings).test(input);

    }

    public static boolean isNiceModel2(String input) {

        final Pattern doubleCharRowNoOverlap = Pattern.compile("(..).*\\1");
        Predicate<String> doubleCharRowNoOverlapPredicate = (s -> doubleCharRowNoOverlap.matcher(s).find());

        // Name finding king 2015
        final Pattern containsDoubleLetterWithSeperator = Pattern.compile("(.).\\1");
        Predicate<String> containsDoubleLetterWithSeperatorPredicate = (s -> containsDoubleLetterWithSeperator.matcher(s).find());

        return doubleCharRowNoOverlapPredicate.and(containsDoubleLetterWithSeperatorPredicate).test(input);

    }

    // Any way to do this better?
    public static int numberOfVowels(String input) {

        int stringLength = input.length();
        int vowelCount = 0;

        for(int i = 0; i < stringLength; i++) {

            switch (input.charAt(i)) {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    vowelCount++;
                    break;
            }

        }

        return vowelCount;

    }

}