//
//  SGMasterViewController.m
//  Cocoheads
//
//  Created by Simon Grätzer on 23.05.13.
//  Copyright (c) 2013 Simon Peter Grätzer. All rights reserved.
//

#import "SGMasterViewController.h"
#import "SGDetailViewController.h"

#include <stdlib.h>     /* srand, rand */
#include <time.h>       /* time */

@implementation SGMasterViewController {
    NSMutableArray *_objects;
}


- (void)viewDidLoad {
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    //self.navigationItem.leftBarButtonItem = self.editButtonItem;

    UIBarButtonItem *addButton = [[UIBarButtonItem alloc] initWithBarButtonSystemItem:UIBarButtonSystemItemRefresh target:self action:@selector(reloadData:)];
    self.navigationItem.leftBarButtonItem = addButton;
    [self reloadData:nil];
    
    self.navigationItem.rightBarButtonItem = [[UIBarButtonItem alloc] initWithTitle:@"Ziehen"
                                                                  style:UIBarButtonItemStyleBordered
                                                                 target:self action:@selector(ziehen)];
    srand (time(NULL));
}

- (void)reloadData:(id)sender {
    
    NSString *path = [[NSBundle mainBundle] pathForResource:@"cocoaheads_5" ofType:@"txt"];
    NSString *data = [NSString stringWithContentsOfFile:path
                                               encoding:NSUTF8StringEncoding
                                                  error:NULL];
    NSArray *people = [data componentsSeparatedByString:@"\n"];
    _objects = [[NSMutableArray alloc] initWithCapacity:people.count];
    
    NSNumberFormatter *numbForm = [NSNumberFormatter new];
    NSDateFormatter *dateF = [NSDateFormatter new];
    [dateF setDateFormat:@"yyyy-MM"];
    
    for (NSString *row in people) {
        if (!row.length) {
            continue;
        }
        
        NSArray *rowData = [row componentsSeparatedByString:@"|"];
        if (rowData.count < 4) {
            continue;
        }
        
        NSString *name = rowData[0];
        NSDate *first = [dateF dateFromString:rowData[1]];
        NSDate *last = [dateF dateFromString:rowData[2]];
        NSNumber *count = [numbForm numberFromString:rowData[3]];
        
        [_objects addObject:@{@"name": name,
                            @"first":first,
         @"last" : last,
         @"count": count}];
    }
    
    [self.tableView reloadData];    
}

- (IBAction)ziehen {
    if (_objects.count < 1) {
        return;
    }
    
    NSMutableArray *pot = [NSMutableArray arrayWithCapacity:_objects.count*3];
    
    for (NSDictionary *pers in _objects) {
        NSDate *first = pers[@"first"];
        NSDate *last = pers[@"last"];
        double count = [pers[@"count"] doubleValue];
        
        double month = [[[NSCalendar currentCalendar] components: NSMonthCalendarUnit
                                                        fromDate: first
                                                          toDate: last
                                                         options: 0] month];
        double result = ceil((count*count)/(month+1));
        for (int i = 0; i < result; i++) {
            [pot addObject:pers];
        }
    }
    [self shuffle:pot];
    int r = rand() % pot.count;
    NSDictionary *result = pot[r];
    SGDetailViewController *detail = [self.storyboard instantiateViewControllerWithIdentifier:@"SGDetailViewController"];
    detail.detailItem = result;
    [self.navigationController pushViewController:detail animated:YES];
    [_objects removeObject:result];
    [self.tableView reloadData];
}

- (void)shuffle:(NSMutableArray *)array {
    NSUInteger count = [array count];
    for (NSUInteger i = 0; i < count; ++i) {
        // Select a random element between i and end of array to swap with.
        NSInteger nElements = count - i;
        NSInteger n = (arc4random() % nElements) + i;
        [array exchangeObjectAtIndex:i withObjectAtIndex:n];
    }
}

#pragma mark - Table View

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return _objects.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"Cell" forIndexPath:indexPath];

    NSDictionary *object = _objects[indexPath.row];
    cell.textLabel.text = object[@"name"];
    return cell;
}

/*
// Override to support rearranging the table view.
- (void)tableView:(UITableView *)tableView moveRowAtIndexPath:(NSIndexPath *)fromIndexPath toIndexPath:(NSIndexPath *)toIndexPath
{
}
*/

/*
// Override to support conditional rearranging of the table view.
- (BOOL)tableView:(UITableView *)tableView canMoveRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Return NO if you do not want the item to be re-orderable.
    return YES;
}
*/

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if ([[segue identifier] isEqualToString:@"showDetail"]) {
        NSIndexPath *indexPath = [self.tableView indexPathForSelectedRow];
        NSDictionary *object = _objects[indexPath.row];
        [[segue destinationViewController] setDetailItem:object];
    }
}

@end
