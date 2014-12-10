//
//  Chart.h
//  IAC
//
//  Created by Simon Grätzer on 01.03.11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <CoreGraphics/CoreGraphics.h>

@interface Chart : UIView {
	NSMutableArray *points;
}

@property(nonatomic, readonly) NSMutableArray *points;

- (void)addPoint:(NSUInteger)point;
@end
