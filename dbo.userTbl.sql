CREATE TABLE [dbo].[userTbl] (
    [id]                      CHAR (9)        NOT NULL,
    [firstName]               NVARCHAR (50)   NOT NULL,
    [lastName]                NVARCHAR (50)   NOT NULL,
    [dateOfBirth]             DATE            NULL,
    [status]                  INT             NOT NULL,
    [yearsInTheProgram]       INT             NULL,
    [requestStatus]           CHAR (1)        NULL,
    [gender]                  CHAR (1)        NULL,
    [phone]                   VARCHAR (10)    NULL,
    [email]                   VARCHAR (4000)  NULL,
    [cityNumber]              INT             NULL,
    [address]                 NVARCHAR (4000) NULL,
    [numOfSiblings]           INT             NULL,
    [academicParents]         INT             NULL,
    [school]                  NVARCHAR (4000) NULL,
    [yearFinishSchool]        INT             NULL,
    [typeOfService]           INT             NOT NULL,
    [academicInstitution]     NVARCHAR (4000) NULL,
    [studyField]              INT             NULL,
    [startYear]               INT             NULL,
    [excpectedCompletionYear] INT             NULL,
    [learningDisabilities]    VARCHAR (3)     NULL,
    [psychometricGrade]       INT             NULL,
    [anotherScholarship]      VARCHAR (3)     NULL,
    [educationFunding]        NVARCHAR (4000) NULL,
    [difficulties]            NVARCHAR (4000) NULL,
    [bankName]                INT             NULL,
    [numOfBank]               INT             NULL,
    [numAccount]              INT             NULL,
    [avergeDegree] NCHAR(10) NULL, 
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([status]) REFERENCES [dbo].[statusTbl] ([numOfStatus]),
    FOREIGN KEY ([cityNumber]) REFERENCES [dbo].[cityTbl] ([sn]),
    FOREIGN KEY ([typeOfService]) REFERENCES [dbo].[serviceTbl] ([sn]),
    FOREIGN KEY ([studyField]) REFERENCES [dbo].[studyFieldTbl] ([sn]),
    FOREIGN KEY ([bankName]) REFERENCES [dbo].[bank] ([sn]),
    CHECK ([id] LIKE replicate('[0-9]', (9))),
    CHECK ([requestStatus] = NULL
           OR [requestStatus] = '?'
           OR [requestStatus] = 'N'
           OR [requestStatus] = 'Y'),
    CHECK ([gender] = 'F'
           OR [gender] = 'M'),
    CHECK ([phone] LIKE replicate('[0-9]', (10))),
    CHECK ([email] LIKE '%_@__%.__%'),
    CHECK ([academicParents] = (2)
           OR [academicParents] = (1)
           OR [academicParents] = (0)),
    CHECK ([startYear] <= [excpectedCompletionYear]),
    CHECK ([learningDisabilities] = 'No'
           OR [learningDisabilities] = 'Yes'),
    CHECK ([anotherScholarship] = 'No'
           OR [anotherScholarship] = 'Yes'),
    CONSTRAINT [check_bank1_nullness] CHECK ([bankName] IS NULL
                                                 AND [numOfBank] IS NULL
                                                 OR [bankName] IS NOT NULL
                                                    AND [numOfBank] IS NOT NULL),
    CONSTRAINT [check_bank2_nullness] CHECK ([numOfBank] IS NULL
                                                 AND [numAccount] IS NULL
                                                 OR [numOfBank] IS NOT NULL
                                                    AND [numAccount] IS NOT NULL)
);

