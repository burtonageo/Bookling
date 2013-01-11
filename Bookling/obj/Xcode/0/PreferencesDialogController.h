// WARNING
// This file has been generated automatically by MonoDevelop to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Cocoa/Cocoa.h>
#import <Foundation/Foundation.h>


@interface PreferencesDialogController : NSWindowController {
	NSSegmentedControl *_viewSelector;
	NSBox *_viewBox;
	NSButton *_acceptButton;
	NSButton *_resetButton;
}

@property (nonatomic, retain) IBOutlet NSSegmentedControl *viewSelector;

@property (nonatomic, retain) IBOutlet NSBox *viewBox;

@property (nonatomic, retain) IBOutlet NSButton *acceptButton;

@property (nonatomic, retain) IBOutlet NSButton *resetButton;

- (IBAction)ResetToDefaults:(id)sender;

- (IBAction)Accept:(id)sender;

- (IBAction)Cancel:(id)sender;

- (IBAction)SwitchView:(id)sender;

@end
