// WARNING
// This file has been generated automatically by MonoDevelop to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Cocoa/Cocoa.h>
#import <Foundation/Foundation.h>


@interface BookMetadataDialogController : NSWindowController {
	NSTextField *_titleField;
	NSTextField *_authorField;
	NSTextField *_genreField;
	NSTextField *_yearField;
	NSTextField *_seriesField;
	NSTextField *_seriesStartField;
	NSTextField *_seriesEndField;
	NSButton *_isSeriesCheckBox;
}

@property (nonatomic, retain) IBOutlet NSTextField *titleField;

@property (nonatomic, retain) IBOutlet NSTextField *authorField;

@property (nonatomic, retain) IBOutlet NSTextField *genreField;

@property (nonatomic, retain) IBOutlet NSTextField *yearField;

@property (nonatomic, retain) IBOutlet NSTextField *seriesField;

@property (nonatomic, retain) IBOutlet NSTextField *seriesStartField;

@property (nonatomic, retain) IBOutlet NSTextField *seriesEndField;

@property (nonatomic, retain) IBOutlet NSButton *isSeriesCheckBox;

- (IBAction)AcceptChanges:(id)sender;

- (IBAction)CloseWindow:(id)sender;

- (IBAction)NextItem:(id)sender;

- (IBAction)PreviousItem:(id)sender;

- (IBAction)SwitchIsInSeries:(id)sender;

@end
