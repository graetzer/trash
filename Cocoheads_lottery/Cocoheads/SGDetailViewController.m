//
//  SGDetailViewController.m
//  Cocoheads
//
//  Created by Simon Grätzer on 23.05.13.
//  Copyright (c) 2013 Simon Peter Grätzer. All rights reserved.
//

#import "SGDetailViewController.h"

@interface SGDetailViewController ()
- (void)configureView;
@end

@implementation SGDetailViewController

#pragma mark - Managing the detail item

- (void)setDetailItem:(id)newDetailItem {
    if (_detailItem != newDetailItem) {
        _detailItem = newDetailItem;
        
        // Update the view.
        [self configureView];
    }
}

- (void)configureView
{
    // Update the user interface for the detail item.
    
    

    if (self.detailItem) {
        self.title = _detailItem[@"name"];
        self.nameLabel.text = _detailItem[@"name"];
        self.startLabel.text = [_detailItem[@"first"] description];
        self.lastLabel.text = [_detailItem[@"last"] description];
        self.countLabel.text = [_detailItem[@"count"] stringValue];
        
        NSDate *first = _detailItem[@"first"];
        NSDate *last = _detailItem[@"last"];
        double count = [_detailItem[@"count"] doubleValue];
        
        double month = [[[NSCalendar currentCalendar] components: NSMonthCalendarUnit
                                                           fromDate: first
                                                             toDate: last
                                                            options: 0] month];
        double result = ceil((count*count)/(month+1));
        self.resultLabel.text = [NSString stringWithFormat:@"%f", result];

//        double distance = [first timeIntervalSinceDate:last];
//        double months = distance/()
    }
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    [self configureView];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
