package day2;

import java.awt.List;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

public class Day_02_01 {

	public static void main(String[] args) {
		// Separate lines
		// Create new Box with each line
		
		ArrayList<Box> boxes = new ArrayList<Box>();
		int wrappingPaperArea = 0;
		int totalRibbonLength = 0;
		File file = null;
		BufferedReader br;
		try {
			// Go through lines and separate them
			file = new File("src/day2/input.txt");
			br = new BufferedReader(new FileReader(file));
			String line = null;  
			while ((line = br.readLine()) != null)  
			{
				boxes.add(new Box(line));
			}
			for(int i = 0; i < boxes.size(); i++) {
				wrappingPaperArea += boxes.get(i).getWrappingPaper();
				totalRibbonLength += boxes.get(i).getRibbonLength();
			}
			System.out.println(wrappingPaperArea);
			System.out.println(totalRibbonLength);
			
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}