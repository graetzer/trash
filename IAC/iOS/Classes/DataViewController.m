//
//  FirstViewController.m
//  IAC
//
//  Created by Simon Grätzer on 01.03.11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "DataViewController.h"
#import "DSActivityView.h"
#import "IACAppDelegate.h"
#import "ASIHTTPRequest.h"
#import "Chart.h"

@implementation DataViewController
@synthesize chart;


// Implement viewDidLoad to do additional setup after loading the view, typically from a nib.
- (void)viewDidLoad {
    [super viewDidLoad];
	timer = [[NSTimer scheduledTimerWithTimeInterval:2 target:self selector:@selector(reloadWithTimer:) userInfo:nil repeats:YES] retain];
}

-(void)reloadWithTimer:(NSTimer *)timer; {
	[self reload];
}

- (IBAction)reload; {
	IACAppDelegate *delegate = (IACAppDelegate *)[[UIApplication sharedApplication]delegate];
	
	NSString *urlString = [NSString stringWithFormat:@"http://%@:8080/", delegate.ip];
	NSURL *url = [NSURL URLWithString:urlString];
	ASIHTTPRequest *request = [ASIHTTPRequest requestWithURL:url];
	[request setTimeOutSeconds:5.0];
	[request startSynchronous];
	NSString *response = [request responseString];
	
	[self.chart.points removeAllObjects];
	
	NSArray *lines = [response componentsSeparatedByString:@"\n"];
	int i = lines.count > 21 ? lines.count - 21 : 0;
	for (; i < [lines count]; i++) {
		NSString *line = [lines objectAtIndex:i];
		NSLog(@"%@", line);
		[self.chart addPoint:[line intValue]];
	}
	
	[self.chart setNeedsDisplay];
}

- (IBAction)dismiss:(id)sender {
    [timer invalidate];
    [self.parentViewController dismissModalViewControllerAnimated:YES];
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation {
    // Overriden to allow any orientation.
    return YES;
}

- (void)didReceiveMemoryWarning {
    // Releases the view if it doesn't have a superview.
    [super didReceiveMemoryWarning];
    
    // Release any cached data, images, etc that aren't in use.
}

- (void)viewDidUnload {
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}


- (void)dealloc {
    [super dealloc];
    [timer release];
}

@end
