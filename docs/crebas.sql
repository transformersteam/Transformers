/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2019/6/10 20:42:40                           */
/*==============================================================*/


drop table if exists ApprActivity;

drop table if exists ApprConfiguration;

drop table if exists ApprHistory;

drop table if exists Attention;

drop table if exists Feedback;

drop table if exists FeedbackLoop;

drop table if exists Files;

drop table if exists Frequency;

drop table if exists Goal;

drop table if exists GoalState;

drop table if exists GoalType;

drop table if exists IndexLevel;

drop table if exists Indexs;

drop table if exists Integral;

drop table if exists Power;

drop table if exists Role;

drop table if exists RolePower;

drop table if exists User;

drop table if exists UserRole;

/*==============================================================*/
/* Table: ApprActivity                                          */
/*==============================================================*/
create table ApprActivity
(
   ApprActivity_Id      int not null auto_increment,
   User_Id              int,
   Goal_Id              int,
   Next_Id              int,
   State_Id             int,
   Department_Id        int,
   ApprConfiguration_Id int,
   ApprActivity_Opinion varchar(50),
   ApprActivity_IsExecute bool,
   ApprActivity_IsUse   bool,
   ApprActivity_CreateTime datetime,
   primary key (ApprActivity_Id)
);

/*==============================================================*/
/* Table: ApprConfiguration                                     */
/*==============================================================*/
create table ApprConfiguration
(
   ApprConfiguration_Id int not null auto_increment,
   User_Id              int,
   Goal_Id              int,
   ApprConfiguration_IsEnable bool,
   ApprConfiguration_CreateTime datetime,
   ApprConfiguration_Nextid int,
   ApprConfiguration_Stateid int,
   Role_Id              int,
   primary key (ApprConfiguration_Id)
);

/*==============================================================*/
/* Table: ApprHistory                                           */
/*==============================================================*/
create table ApprHistory
(
   ApprHistory_Id       int not null auto_increment,
   ApprActivity_Id      int,
   ApprHistory_CreateTime datetime,
   primary key (ApprHistory_Id)
);

/*==============================================================*/
/* Table: Attention                                             */
/*==============================================================*/
create table Attention
(
   Attention_Id         int not null auto_increment,
   Goal_Id              int,
   User_Id              int,
   Attention_IsUse      bool,
   Attention_CreateTime datetime,
   primary key (Attention_Id)
);

/*==============================================================*/
/* Table: Feedback                                              */
/*==============================================================*/
create table Feedback
(
   Feedback_Id          int not null auto_increment,
   Goal_Id              int,
   State_Id             int,
   Feedback_WorkEvolve  varchar(200),
   Feedback_DayEvolve   varhchar(200),
   Feedback_Question    varchar(200),
   Feedback_Measure     varchar(200),
   Feedback_CoordinateMatters varchar(200),
   Feedback_NowEvolve   int,
   primary key (Feedback_Id)
);

/*==============================================================*/
/* Table: FeedbackLoop                                          */
/*==============================================================*/
create table FeedbackLoop
(
   FeedbackLoop_Id      int not null auto_increment,
   FeedbackLoop_Times   datetime,
   FeedbackLoop_Content varchar(50),
   FeedbackLoop_UpdateTime datetime,
   FeedbackLoop_CreateTime datetime,
   primary key (FeedbackLoop_Id)
);

/*==============================================================*/
/* Table: Files                                                 */
/*==============================================================*/
create table Files
(
   Files_Id             int not null auto_increment,
   File_Name            name,
   File_Url             varchar(50),
   Goal_Id              int,
   CreateTime           datetime,
   primary key (Files_Id)
);

/*==============================================================*/
/* Table: Frequency                                             */
/*==============================================================*/
create table Frequency
(
   Frequency_Id         int not null auto_increment,
   Frequency_Name       varchar(50),
   Frequency_CreateTime datetime,
   Frequency_IsUse      bool,
   primary key (Frequency_Id)
);

/*==============================================================*/
/* Table: Goal                                                  */
/*==============================================================*/
create table Goal
(
   Goal_Id              int not null auto_increment,
   Goal_Name            varchar(50),
   GoalState_Id         int,
   Role_Id              int,
   GoalType_Id          int,
   IndexLevel_Id        int,
   Frequency_Id         int,
   Goal_StartTime       datetime,
   Goal_EndTime         datetime,
   Goal_Period          datetime,
   Goal_Unit            varchar(50),
   Goal_ChargePeople    varchar(50),
   Goal_Weight          int,
   Goal_Informant       varchar(50),
   Goal_Organiser       varchar(50),
   Goal_Formula         varchar(50),
   Goal_Sources         varchar(50),
   File_Id              int,
   Goal_CreateTime      datetime,
   primary key (Goal_Id)
);

/*==============================================================*/
/* Table: GoalState                                             */
/*==============================================================*/
create table GoalState
(
   GoalState_Id         int not null auto_increment,
   GoalState_Name       varchar(50),
   GoalState_Explain    varchar(50),
   GoalState_IsUse      bool,
   GoalState_CreateTime datetime,
   primary key (GoalState_Id)
);

/*==============================================================*/
/* Table: GoalType                                              */
/*==============================================================*/
create table GoalType
(
   GoalType_Id          int not null auto_increment,
   GoalType_Name        varchar(50),
   GoalType_PId         int,
   GoalType_IsUse       bool,
   GoalType_CreateTime  datetime,
   primary key (GoalType_Id)
);

/*==============================================================*/
/* Table: IndexLevel                                            */
/*==============================================================*/
create table IndexLevel
(
   IndexLevel_Id        int not null auto_increment,
   IndexLevel_Grade     varchar(50),
   IndexLevel_CreateTime datetime,
   IndexLevel_IsUse     bool,
   primary key (IndexLevel_Id)
);

/*==============================================================*/
/* Table: Indexs                                                */
/*==============================================================*/
create table Indexs
(
   Indexs_Id            int not null auto_increment,
   Goal_Id              int,
   Indexs_January       int,
   Indexs_February      int,
   Indexs_March         int,
   Indexs_April         int,
   Indexs_May           int,
   Indexs_June          int,
   Indexs_July          int,
   Indexs_August        int,
   Indexs_September     int,
   Indexs_October       int,
   Indexs_November      int,
   Indexs_YearTarget    int,
   Indexs_CreateTime    datetime,
   primary key (Indexs_Id)
);

/*==============================================================*/
/* Table: Integral                                              */
/*==============================================================*/
create table Integral
(
   Integral_Id          int not null auto_increment,
   User_Id              int,
   Integral_Num         int,
   primary key (Integral_Id)
);

/*==============================================================*/
/* Table: Power                                                 */
/*==============================================================*/
create table Power
(
   Power_Id             int not null auto_increment,
   Power_Name           national varchar(50),
   Power_Url            national varchar(200),
   Power_PId            int,
   Power_SortId         int,
   Power_IsEnable       bool,
   Power_CreateTime     datetime,
   primary key (Power_Id)
);

/*==============================================================*/
/* Table: Role                                                  */
/*==============================================================*/
create table Role
(
   Role_Id              int not null auto_increment,
   Role_Name            national varchar(50),
   Role_Pid             int,
   Role_Content         national varchar(200),
   Role_IsEnable        bool,
   Role_CreateTime      datetime,
   Role_CreatePeople    national varchar(50),
   Role_ModifyPeople    national varchar(50),
   Role_ModifyTime      datetime,
   primary key (Role_Id)
);

/*==============================================================*/
/* Table: RolePower                                             */
/*==============================================================*/
create table RolePower
(
   RolePower_Id         int not null auto_increment,
   Role_Id              int,
   Power_Id             int,
   primary key (RolePower_Id)
);

/*==============================================================*/
/* Table: User                                                  */
/*==============================================================*/
create table User
(
   User_Id              int not null auto_increment,
   User_Name            national varchar(20),
   User_Pass            national varchar(20),
   User_RealName        national varchar(20),
   User_RoleName        national varchar(50),
   User_IsEnable        bool,
   User_CreateTime      datetime,
   primary key (User_Id)
);

/*==============================================================*/
/* Table: UserRole                                              */
/*==============================================================*/
create table UserRole
(
   UserRole_Id          int not null auto_increment,
   User_Id              int,
   Role_Id              int,
   primary key (UserRole_Id)
);

