    //
//  ConfigurationView.m
//  IAC
//
//  Created by Simon Grätzer on 01.03.11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "ConfigurationView.h"
#import "IACAppDelegate.h"
#import "DSActivityView.h"

@implementation ConfigurationView
@synthesize ipField;

 // The designated initializer.  Override if you create the controller programmatically and want to perform customization that is not appropriate for viewDidLoad.
/*
- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil {
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization.
    }
    return self;
}
*/

/*
// Implement viewDidLoad to do additional setup after loading the view, typically from a nib.
- (void)viewDidLoad {
    [super viewDidLoad];
}
*/

- (IBAction)processIP; {
	IACAppDelegate *delegate = (IACAppDelegate *)[[UIApplication sharedApplication]delegate];
	delegate.ip = ipField.text;
	
	self.modalPresentationStyle = UIModalPresentationFormSheet;
	self.modalTransitionStyle = UIModalTransitionStyleFlipHorizontal;
	[self presentModalViewController:delegate.tabBarController animated:YES];
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation {
    // Overriden to allow any orientation.
    return YES;
}


- (void)didReceiveMemoryWarning {
    // Releases the view if it doesn't have a superview.
    [super didReceiveMemoryWarning];
    
    // Release any cached data, images, etc. that aren't in use.
}


- (void)viewDidUnload {
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}


- (void)dealloc {
    [super dealloc];
}


@end
