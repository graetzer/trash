//
//  SecondViewController.h
//  IAC
//
//  Created by Simon Grätzer on 01.03.11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>


@interface ControlViewController : UIViewController {
	UITextField *duration;
	UITextField *position;
	UITextField *width;
	UISwitch *actionType;
}

@property(nonatomic, retain) IBOutlet UITextField *duration;
@property(nonatomic, retain) IBOutlet UITextField *position;
@property(nonatomic, retain) IBOutlet UITextField *width;
@property(nonatomic, retain) IBOutlet UISwitch *actionType;

- (IBAction)sendCmd;
@end
