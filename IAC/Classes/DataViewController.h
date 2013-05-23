//
//  FirstViewController.h
//  IAC
//
//  Created by Simon Grätzer on 01.03.11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>


@class Chart;
@interface DataViewController : UIViewController {
	Chart *chart;
    NSTimer *timer;
}
@property (nonatomic, retain)IBOutlet Chart *chart;

- (IBAction)reload;
- (IBAction)dismiss:(id)sender;

@end
