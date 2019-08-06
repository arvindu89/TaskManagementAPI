create table dbo.ParentTask
( 
  Parent_ID int NOT NULL IDENTITY(1,1),
  Parent_Task nvarchar(150) NOT NULL,
  CONSTRAINT ParentTask_pk PRIMARY KEY (Parent_ID)
);


create table dbo.Task
( 
  Task_ID int NOT NULL IDENTITY(1,1),
  Parent_ID int NOT NULL,
  Task nvarchar(150) NOT NULL,
  Start_Date datetime null,
  End_Date datetime null,
  Priority int null,
  IsCompleted bit not null,
  CONSTRAINT fk_parent_id
    FOREIGN KEY (Parent_ID)
    REFERENCES ParentTask (Parent_ID),
  CONSTRAINT Task_pk PRIMARY KEY (Task_ID)
);
