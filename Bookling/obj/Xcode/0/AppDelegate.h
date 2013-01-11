// WARNING
// This file has been generated automatically by MonoDevelop to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Cocoa/Cocoa.h>
#import <Foundation/Foundation.h>


@interface AppDelegate : NSObject {
	NSWindow *_mainWindow;
	NSBox *_libraryBox;
	NSOutlineView *_librarySourceOutline;
	NSSegmentedControl *_viewSwitcher;
	NSSearchField *_searchBox;
	NSButton *_shareButton;
	NSMenuItem *_listViewMenuItem;
	NSMenuItem *_gridViewMenuItem;
	NSSplitView *_splitView;
}

@property (nonatomic, retain) IBOutlet NSWindow *mainWindow;

@property (nonatomic, retain) IBOutlet NSBox *libraryBox;

@property (nonatomic, retain) IBOutlet NSOutlineView *librarySourceOutline;

@property (nonatomic, retain) IBOutlet NSSegmentedControl *viewSwitcher;

@property (nonatomic, retain) IBOutlet NSSearchField *searchBox;

@property (nonatomic, retain) IBOutlet NSButton *shareButton;

@property (nonatomic, retain) IBOutlet NSMenuItem *listViewMenuItem;

@property (nonatomic, retain) IBOutlet NSMenuItem *gridViewMenuItem;

@property (nonatomic, retain) IBOutlet NSSplitView *splitView;

- (IBAction)ShowAboutDialog:(id)sender;

- (IBAction)ShowPreferencesDialog:(id)sender;

- (IBAction)ShowInfoDialog:(id)sender;

- (IBAction)ImportFile:(id)sender;

- (IBAction)ViewAsList:(id)sender;

- (IBAction)ViewAsGrid:(id)sender;

- (IBAction)SwitchView:(id)sender;

@end
