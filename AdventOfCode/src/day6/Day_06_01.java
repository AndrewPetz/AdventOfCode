package day6;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

public class Day_06_01 {

	public static void main(String[] args) {
		int[][] grid = new int[1000][1000];
		
		// File IO
		File file = null;
		BufferedReader br;
		try {
			// Go through lines and separate them
			file = new File("src/day6/input.txt");
			br = new BufferedReader(new FileReader(file));
			String line = null;  
			while ((line = br.readLine()) != null)  
			{
				String[] lineSplit = line.split(" ");
				for(int i = 0; i < lineSplit.length; i++) {
					System.out.println(lineSplit[i]);
				}
				System.out.println(line);
			}
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	
}