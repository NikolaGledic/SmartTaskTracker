CREATE TABLE [dbo].[Users] (
    [Id]           UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [Username]     NVARCHAR(100)      NOT NULL UNIQUE,
    [Email]        NVARCHAR(255)      NOT NULL UNIQUE,
    [PasswordHash] NVARCHAR(512)      NOT NULL,
    [CreatedAt]    DATETIME2          NOT NULL DEFAULT SYSUTCDATETIME()
);

-- 2. Teams
CREATE TABLE [dbo].[Teams] (
    [Id]        UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [Name]      NVARCHAR(100)     NOT NULL,
    [CreatedAt] DATETIME2         NOT NULL DEFAULT SYSUTCDATETIME()
);

-- 3. TeamUsers (M:N)
CREATE TABLE [dbo].[TeamUsers] (
    [TeamId] UNIQUEIDENTIFIER NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [Role]   NVARCHAR(50)      NOT NULL,
    CONSTRAINT PK_TeamUsers PRIMARY KEY (TeamId, UserId),
    CONSTRAINT FK_TU_Teams FOREIGN KEY (TeamId) REFERENCES dbo.Teams(Id),
    CONSTRAINT FK_TU_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(Id)
);

-- 4. Tasks
CREATE TABLE [dbo].[Tasks] (
    [Id]          UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [Title]       NVARCHAR(200)     NOT NULL,
    [Description] NVARCHAR(MAX)     NULL,
    [Status]      NVARCHAR(50)      NOT NULL, -- npr. 'New','InProgress','Done'
    [Deadline]    DATETIME2         NULL,
    [AssigneeId]  UNIQUEIDENTIFIER  NULL,
    [CreatorId]   UNIQUEIDENTIFIER  NOT NULL,
    [CreatedAt]   DATETIME2         NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_Task_Assignee FOREIGN KEY (AssigneeId) REFERENCES dbo.Users(Id),
    CONSTRAINT FK_Task_Creator  FOREIGN KEY (CreatorId)  REFERENCES dbo.Users(Id)
);

-- 5. Comments
CREATE TABLE [dbo].[Comments] (
    [Id]        UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [TaskId]    UNIQUEIDENTIFIER NOT NULL,
    [AuthorId]  UNIQUEIDENTIFIER NOT NULL,
    [Content]   NVARCHAR(MAX)     NOT NULL,
    [CreatedAt] DATETIME2         NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_Comment_Task   FOREIGN KEY (TaskId)   REFERENCES dbo.Tasks(Id),
    CONSTRAINT FK_Comment_User   FOREIGN KEY (AuthorId) REFERENCES dbo.Users(Id)
);

-- 6. ExternalIntegrations (npr. weather cache)
CREATE TABLE [dbo].[ExternalIntegrations] (
    [Id]           UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [ServiceName]  NVARCHAR(100)     NOT NULL,
    [LastFetched]  DATETIME2         NOT NULL,
    [Payload]      NVARCHAR(MAX)     NOT NULL
);