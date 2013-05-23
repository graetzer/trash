//
//  ConfigurationView.h
//  IAC
//
//  Created by Simon Grätzer on 01.03.11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>


@interface ConfigurationView : UIViewController {
	UITextField *ipField;
}

@property (nonatomic, retain) IBOutlet UITextField *ipField;

- (IBAction)processIP;

@end
