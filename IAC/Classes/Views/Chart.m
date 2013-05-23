//
//  Chart.m
//  IAC
//
//  Created by Simon Grätzer on 01.03.11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "Chart.h"


@implementation Chart
@synthesize points;

- (id)initWithFrame:(CGRect)frame {
    
    self = [super initWithFrame:frame];
    if (self) {
        // Initialization code.
		points = [[NSMutableArray alloc]initWithCapacity:50];
    }
    return self;
}
//

- (id)initWithCoder:(NSCoder *)aDecoder  {
	self = [super initWithCoder:aDecoder];
	if (self) {
        // Initialization code.
		points = [[NSMutableArray alloc]initWithCapacity:50];
    }
    return self;
}

- (void)addPoint:(NSUInteger)point; {
	[points addObject:[NSNumber numberWithInt:point]];
}

// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
- (void)drawRect:(CGRect)rect {
    // Drawing code.
	CGContextRef context = UIGraphicsGetCurrentContext();
	
	CGContextSetStrokeColorWithColor(context, [UIColor redColor].CGColor);
	//Set the width of the pen mark
	CGContextSetLineWidth(context, 5.0);
	
	// Draw a line
	//Start at this point
	CGContextMoveToPoint(context, 0.0, rect.size.height);
	//Give instructions to the CGContext
	//(move "pen" around the screen)
	CGFloat x = 0.0;
	
	for (NSNumber *number in points) {
		CGFloat y = (CGFloat)[number integerValue];
		CGContextAddLineToPoint(context, x,rect.size.height - y*2);
		
		//NSString *desc = [NSString stringWithFormat:@"%f", x];
		//CGContextShowTextAtPoint(context, x, rect.size.height - y -50, [desc cStringUsingEncoding:NSUTF8StringEncoding], [desc length]);
		x += 50.0;
	}
	
	
	//Draw it
	CGContextStrokePath(context);
}


- (void)dealloc {
    [super dealloc];
}


@end
