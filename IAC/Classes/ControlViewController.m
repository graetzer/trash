//
//  SecondViewController.m
//  IAC
//
//  Created by Simon Grätzer on 01.03.11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "ControlViewController.h"
#import "IACAppDelegate.h"
#import "ASIHTTPRequest.h"
#import "DSActivityView.h"

@implementation ControlViewController
@synthesize duration,position,width,actionType;

IACAppDelegate *delegate;


// Implement viewDidLoad to do additional setup after loading the view, typically from a nib.
- (void)viewDidLoad {
    [super viewDidLoad];
	delegate = (IACAppDelegate *)[[UIApplication sharedApplication]delegate];
}


// Override to allow orientations other than the default portrait orientation.
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
}

- (IBAction)sendCmd; {
	[DSBezelActivityView activityViewForView:delegate.window withLabel:@"Sende Commandos"];
	NSString *actionString = actionType.on ? @"true":@"false";

	NSString *urlString = [NSString stringWithFormat:@"http://%@/%@/%@/%@/%@", delegate.ip, actionString, duration.text, position.text, width.text];
	NSURL *url = [NSURL URLWithString:urlString];
	ASIHTTPRequest *request = [ASIHTTPRequest requestWithURL:url];
	[request setTimeOutSeconds:5.0];
	[request startSynchronous];
	[DSBezelActivityView removeViewAnimated:YES];
}

@end
