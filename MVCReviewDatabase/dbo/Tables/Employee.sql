CREATE TABLE [dbo].[Employee] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [EmployeeName] NVARCHAR (50)   NULL,
    [Salary]       DECIMAL (18, 2) NULL,
    [Age]          INT             NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC)
);

