﻿CREATE TABLE Batches
(
	[Id] INTEGER PRIMARY KEY, 
    [Beer] INTEGER NOT NULL,
	[BatchNumber] INTEGER not null,
	[BatchName] TEXT null,
	[Status] TEXT null,
	[SubStatus] TEXT null,
	[Brewers] TEXT null, 
	[Yeast] TEXT null,
	[PreBoilGravity] decimal(4,3) null,
	[OriginalGravity] decimal(4,3) null,
	[FinalGravity] decimal(4,3) null,
	[ABV] decimal(2,2) null,
	[PintsRemaining]  decimal null,
	[DateBrewed] DateTime null,
	[DatePackaged] DateTime null,
	[DateTapped] DateTime null,
	[BrewingNotes] TEXT null,
	[TastingNotes] TEXT null,
	[Created] TEXT NOT null DEFAULT CURRENT_TIMESTAMP,
	[CreatedBy] TEXT null,
	FOREIGN KEY(Beer) REFERENCES Beers(Id)
)
