using System;
using DongXu.Target.Model.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DongXu.Target.Model
{
    public partial class dxdatabaseContext : DbContext
    {
        public dxdatabaseContext()
        {
        }

        public dxdatabaseContext(DbContextOptions<dxdatabaseContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 审批活动表
        /// </summary>
        public virtual DbSet<Appractivity> Appractivity { get; set; }

        /// <summary>
        /// 审批配置表
        /// </summary>
        public virtual DbSet<Apprconfiguration> Apprconfiguration { get; set; }

        /// <summary>
        /// 审批历史表
        /// </summary>
        public virtual DbSet<Apprhistory> Apprhistory { get; set; }

        /// <summary>
        /// 关注表
        /// </summary>
        public virtual DbSet<Attention> Attention { get; set; }

        /// <summary>
        /// 反馈表
        /// </summary>
        public virtual DbSet<Feedback> Feedback { get; set; }

        /// <summary>
        /// 反馈周期表
        /// </summary>
        public virtual DbSet<Feedbackloop> Feedbackloop { get; set; }

        /// <summary>
        /// 文件表
        /// </summary>
        public virtual DbSet<Files> Files { get; set; }

        /// <summary>
        /// 反馈频次表
        /// </summary>
        public virtual DbSet<Frequency> Frequency { get; set; }

        /// <summary>
        /// 目标表
        /// </summary>
        public virtual DbSet<Goal> Goal { get; set; }

        /// <summary>
        /// 目标状态表
        /// </summary>
        public virtual DbSet<Goalstate> Goalstate { get; set; }

        /// <summary>
        /// 目标类型
        /// </summary>
        public virtual DbSet<Goaltype> Goaltype { get; set; }

        /// <summary>
        /// 指标等级表
        /// </summary>
        public virtual DbSet<Indexlevel> Indexlevel { get; set; }

        /// <summary>
        /// 指标吧
        /// </summary>
        public virtual DbSet<Indexs> Indexs { get; set; }

        /// <summary>
        /// 积分表
        /// </summary>
        public virtual DbSet<Integral> Integral { get; set; }

        /// <summary>
        /// 权限表
        /// </summary>
        public virtual DbSet<Power> Power { get; set; }

        /// <summary>
        /// 角色表
        /// </summary>
        public virtual DbSet<Role> Role { get; set; }

        /// <summary>
        /// 角色权限表
        /// </summary>
        public virtual DbSet<Rolepower> Rolepower { get; set; }

        /// <summary>
        /// 用户表
        /// </summary>
        public virtual DbSet<User> User { get; set; }

        /// <summary>
        /// 用户角色表
        /// </summary>
        public virtual DbSet<Userrole> Userrole { get; set; }

        public virtual DbSet<WaitRead> WaitRead { get; set; }



        public DbQuery<UserQuery> UserQuery { get; set; }

        public DbQuery<NumQuery> NumQuery { get; set; } 







        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=169.254.105.125;User Id=root;Password=1234567;Database=dxdatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appractivity>(entity =>
            {
                entity.ToTable("appractivity");

                entity.Property(e => e.ApprActivityId)
                    .HasColumnName("ApprActivity_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApprActivityCreateTime)
                    .HasColumnName("ApprActivity_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprActivityIsExecute)
                    .HasColumnName("ApprActivity_IsExecute")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ApprActivityIsUse)
                    .HasColumnName("ApprActivity_IsUse")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ApprActivityOpinion)
                    .HasColumnName("ApprActivity_Opinion")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ApprConfigurationId)
                    .HasColumnName("ApprConfiguration_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("Department_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoalId)
                    .HasColumnName("Goal_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NextId)
                    .HasColumnName("Next_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StateId)
                    .HasColumnName("State_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Apprconfiguration>(entity =>
            {
                entity.ToTable("apprconfiguration");

                entity.Property(e => e.ApprConfigurationId)
                    .HasColumnName("ApprConfiguration_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApprConfigurationCreateTime)
                    .HasColumnName("ApprConfiguration_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprConfigurationIsEnable)
                    .HasColumnName("ApprConfiguration_IsEnable")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ApprConfigurationNextid)
                    .HasColumnName("ApprConfiguration_Nextid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApprConfigurationStateid)
                    .HasColumnName("ApprConfiguration_Stateid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoalId)
                    .HasColumnName("Goal_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Apprhistory>(entity =>
            {
                entity.ToTable("apprhistory");

                entity.Property(e => e.ApprHistoryId)
                    .HasColumnName("ApprHistory_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApprActivityId)
                    .HasColumnName("ApprActivity_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApprHistoryCreateTime)
                    .HasColumnName("ApprHistory_CreateTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Attention>(entity =>
            {
                entity.ToTable("attention");

                entity.Property(e => e.AttentionId)
                    .HasColumnName("Attention_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AttentionCreateTime)
                    .HasColumnName("Attention_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AttentionIsUse)
                    .HasColumnName("Attention_IsUse")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.GoalId)
                    .HasColumnName("Goal_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.Property(e => e.FeedbackId)
                    .HasColumnName("Feedback_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FeedbackCoordinateMatters)
                    .HasColumnName("Feedback_CoordinateMatters")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FeedbackDayEvolve)
                    .HasColumnName("Feedback_DayEvolve")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FeedbackMeasure)
                    .HasColumnName("Feedback_Measure")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FeedbackNowEvolve)
                    .HasColumnName("Feedback_NowEvolve")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FeedbackQuestion)
                    .HasColumnName("Feedback_Question")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FeedbackWorkEvolve)
                    .HasColumnName("Feedback_WorkEvolve")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.GoalId)
                    .HasColumnName("Goal_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StateId)
                    .HasColumnName("State_Id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Feedbackloop>(entity =>
            {
                entity.ToTable("feedbackloop");

                entity.Property(e => e.FeedbackLoopId)
                    .HasColumnName("FeedbackLoop_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FeedbackLoopContent)
                    .HasColumnName("FeedbackLoop_Content")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FeedbackLoopCreateTime)
                    .HasColumnName("FeedbackLoop_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FeedbackLoopTimes)
                    .HasColumnName("FeedbackLoop_Times")
                    .HasColumnType("datetime");

                entity.Property(e => e.FeedbackLoopUpdateTime)
                    .HasColumnName("FeedbackLoop_UpdateTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.ToTable("files");

                entity.Property(e => e.FilesId)
                    .HasColumnName("Files_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .HasColumnName("File_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FileUrl)
                    .HasColumnName("File_Url")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GoalId)
                    .HasColumnName("Goal_Id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Frequency>(entity =>
            {
                entity.ToTable("frequency");

                entity.Property(e => e.FrequencyId)
                    .HasColumnName("Frequency_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FrequencyCreateTime)
                    .HasColumnName("Frequency_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FrequencyIsUse)
                    .HasColumnName("Frequency_IsUse")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.FrequencyName)
                    .HasColumnName("Frequency_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.ToTable("goal");

                entity.Property(e => e.GoalId)
                    .HasColumnName("Goal_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FileId)
                    .HasColumnName("File_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FrequencyId)
                    .HasColumnName("Frequency_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoalChargePeople)
                    .HasColumnName("Goal_ChargePeople")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GoalCreateTime)
                    .HasColumnName("Goal_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.GoalEndTime)
                    .HasColumnName("Goal_EndTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.GoalFormula)
                    .HasColumnName("Goal_Formula")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GoalInformant)
                    .HasColumnName("Goal_Informant")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GoalName)
                    .HasColumnName("Goal_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GoalOrganiser)
                    .HasColumnName("Goal_Organiser")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GoalPeriod)
                    .HasColumnName("Goal_Period")
                    .HasColumnType("datetime");

                entity.Property(e => e.GoalSources)
                    .HasColumnName("Goal_Sources")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GoalStartTime)
                    .HasColumnName("Goal_StartTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.GoalStateId)
                    .HasColumnName("GoalState_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoalTypeId)
                    .HasColumnName("GoalType_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoalUnit)
                    .HasColumnName("Goal_Unit")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GoalWeight)
                    .HasColumnName("Goal_Weight")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexLevelId)
                    .HasColumnName("IndexLevel_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BusinessState)
                    .HasColumnName("Business_State")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FeedbackId)
                    .HasColumnName("Feedback_Id")
                    .HasColumnType("int(11)");
                
            });

            modelBuilder.Entity<Goalstate>(entity =>
            {
                entity.ToTable("goalstate");

                entity.Property(e => e.GoalStateId)
                    .HasColumnName("GoalState_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoalStateCreateTime)
                    .HasColumnName("GoalState_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.GoalStateExplain)
                    .HasColumnName("GoalState_Explain")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GoalStateIsUse)
                    .HasColumnName("GoalState_IsUse")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.GoalStateName)
                    .HasColumnName("GoalState_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Goaltype>(entity =>
            {
                entity.ToTable("goaltype");

                entity.Property(e => e.GoalTypeId)
                    .HasColumnName("GoalType_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoalTypeCreateTime)
                    .HasColumnName("GoalType_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.GoalTypeIsUse)
                    .HasColumnName("GoalType_IsUse")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.GoalTypeName)
                    .HasColumnName("GoalType_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GoalTypePid)
                    .HasColumnName("GoalType_PId")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Indexlevel>(entity =>
            {
                entity.ToTable("indexlevel");

                entity.Property(e => e.IndexLevelId)
                    .HasColumnName("IndexLevel_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexLevelCreateTime)
                    .HasColumnName("IndexLevel_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IndexLevelGrade)
                    .HasColumnName("IndexLevel_Grade")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IndexLevelIsUse)
                    .HasColumnName("IndexLevel_IsUse")
                    .HasColumnType("tinyint(1)");
            });

            modelBuilder.Entity<Indexs>(entity =>
            {
                entity.ToTable("indexs");

                entity.Property(e => e.IndexsId)
                    .HasColumnName("Indexs_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoalId)
                    .HasColumnName("Goal_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexsApril)
                    .HasColumnName("Indexs_April")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexsAugust)
                    .HasColumnName("Indexs_August")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexsCreateTime)
                    .HasColumnName("Indexs_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IndexsFebruary)
                    .HasColumnName("Indexs_February")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexsJanuary)
                    .HasColumnName("Indexs_January")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexsJuly)
                    .HasColumnName("Indexs_July")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexsJune)
                    .HasColumnName("Indexs_June")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexsMarch)
                    .HasColumnName("Indexs_March")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexsMay)
                    .HasColumnName("Indexs_May")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexsNovember)
                    .HasColumnName("Indexs_November")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexsOctober)
                    .HasColumnName("Indexs_October")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexsSeptember)
                    .HasColumnName("Indexs_September")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndexsYearTarget)
                    .HasColumnName("Indexs_YearTarget")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Integral>(entity =>
            {
                entity.ToTable("integral");

                entity.Property(e => e.IntegralId)
                    .HasColumnName("Integral_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IntegralNum)
                    .HasColumnName("Integral_Num")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Goad_Id)
                    .HasColumnName("Goad_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleId) 
                    .HasColumnName("Role_Id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Power>(entity =>
            {
                entity.ToTable("power");

                entity.Property(e => e.PowerId)
                    .HasColumnName("Power_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PowerCreateTime)
                    .HasColumnName("Power_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PowerIsEnable)
                    .HasColumnName("Power_IsEnable")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.PowerName)
                    .HasColumnName("Power_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PowerPid)
                    .HasColumnName("Power_PId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PowerSortId)
                    .HasColumnName("Power_SortId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PowerUrl)
                    .HasColumnName("Power_Url")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleContent)
                    .HasColumnName("Role_Content")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.RoleCreatePeople)
                    .HasColumnName("Role_CreatePeople")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RoleCreateTime)
                    .HasColumnName("Role_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleIsEnable)
                    .HasColumnName("Role_IsEnable")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleModifyPeople)
                    .HasColumnName("Role_ModifyPeople")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RoleModifyTime)
                    .HasColumnName("Role_ModifyTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .HasColumnName("Role_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RolePid)
                    .HasColumnName("Role_Pid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleIdentify)
                     .HasColumnName("Role_Identify")
                     .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Rolepower>(entity =>
            {
                entity.ToTable("rolepower");

                entity.Property(e => e.RolePowerId)
                    .HasColumnName("RolePower_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PowerId)
                    .HasColumnName("Power_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_Id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserCreateTime)
                    .HasColumnName("User_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserIsEnable)
                    .HasColumnName("User_IsEnable")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.UserName)
                    .HasColumnName("User_Name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.UserPass)
                    .HasColumnName("User_Pass")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.UserRealName)
                    .HasColumnName("User_RealName")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.UserRoleName)
                    .HasColumnName("User_RoleName")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Userrole>(entity =>
            {
                entity.ToTable("userrole");

                entity.Property(e => e.UserRoleId)
                    .HasColumnName("UserRole_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .HasColumnType("int(11)");
            });
        }
    }
}
