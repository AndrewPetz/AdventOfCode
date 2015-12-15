package day2;

public class Box {
	
	public String line;
	public int length;
	public int width;
	public int height;
	
	public Box(String line) {
		this.length = getLength(line);
		this.width = getWidth(line);
		this.height = getHeight(line);
	}
	
	public int getWrappingPaper() {
		// 2*l*w + 2*w*h + 2*h*l
		return ((2*length*width) + (2*width*height) + (2*height*length) + getSmallestSideArea());
	}
	
	private int getSmallestSideArea() {
		int lw = length*width;
		int lh = length*height;
		int wh = width*height;
		
		return Math.min(lw, Math.min(lh, wh));
	}
	
	public int getRibbonLength() {
		int lwFace = (2*length) + (2*width);
		int lhFace = (2*length) + (2*height);
		int whFace = (2*width) + (2*height);
		int volume = length*width*height;
		
		return Math.min(lwFace, Math.min(lhFace, whFace)) + volume;
	}
	
	private int getLength(String line) {
		String[] lwh = line.split("x");
		int w = Integer.parseInt(lwh[0]);
		return w;
	}
	
	private int getWidth(String line) {
		String[] lwh = line.split("x");
		int w = Integer.parseInt(lwh[1]);
		return w;
	}
	
	private int getHeight(String line) {
		String[] lwh = line.split("x");
		int w = Integer.parseInt(lwh[2]);
		return w;
	}
}