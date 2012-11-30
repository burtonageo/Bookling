// WARNING
// This file has been generated automatically by MonoDevelop to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Cocoa/Cocoa.h>
#import <Foundation/Foundation.h>


@interface BookMetadataDialogController : NSWindowController {
	NSTextField *_TitleField;
	NSTextField *_AuthorField;
	NSTextField *_GenreField;
	NSTextField *_YearField;
	NSTextField *_SeriesField;
	NSTextField *_SeriesStartField;
	NSTextField *_SeriesEndField;
}

@property (nonatomic, retain) IBOutlet NSTextField *TitleField;

@property (nonatomic, retain) IBOutlet NSTextField *AuthorField;

@property (nonatomic, retain) IBOutlet NSTextField *GenreField;

@property (nonatomic, retain) IBOutlet NSTextField *YearField;

@property (nonatomic, retain) IBOutlet NSTextField *SeriesField;

@property (nonatomic, retain) IBOutlet NSTextField *SeriesStartField;

@property (nonatomic, retain) IBOutlet NSTextField *SeriesEndField;

- (IBAction)AcceptChanges:(id)sender;

@end
