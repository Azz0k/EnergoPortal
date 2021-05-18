using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DBRepository
{
    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abc3x> Abc3xes { get; set; }
        public virtual DbSet<Abc4x> Abc4xes { get; set; }
        public virtual DbSet<Abc8x> Abc8xes { get; set; }
        public virtual DbSet<Ahtung> Ahtungs { get; set; }
        public virtual DbSet<C> Cs { get; set; }
        public virtual DbSet<CiscoVpn> CiscoVpns { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<ComputersCopy> ComputersCopies { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactsDcenergoRu> ContactsDcenergoRus { get; set; }
        public virtual DbSet<ContactsEnergospbRu> ContactsEnergospbRus { get; set; }
        public virtual DbSet<ContactsTdenergospbRu> ContactsTdenergospbRus { get; set; }
        public virtual DbSet<Control> Controls { get; set; }
        public virtual DbSet<ControlCopy> ControlCopies { get; set; }
        public virtual DbSet<ControlCopyCopy> ControlCopyCopies { get; set; }
        public virtual DbSet<Copy> Copies { get; set; }
        public virtual DbSet<CsCopy> CsCopies { get; set; }
        public virtual DbSet<CsCopyCopy> CsCopyCopies { get; set; }
        public virtual DbSet<Def9x> Def9xes { get; set; }
        public virtual DbSet<Def9xRu> Def9xRus { get; set; }
        public virtual DbSet<Def9xSpb> Def9xSpbs { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Dm> Dms { get; set; }
        public virtual DbSet<Fiz> Fizs { get; set; }
        public virtual DbSet<FizCopy> FizCopies { get; set; }
        public virtual DbSet<Freedisk> Freedisks { get; set; }
        public virtual DbSet<FreediskCopy> FreediskCopies { get; set; }
        public virtual DbSet<GoVoIp> GoVoIps { get; set; }
        public virtual DbSet<InGet> InGets { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<LogAdmin> LogAdmins { get; set; }
        public virtual DbSet<LogAsterisk> LogAsterisks { get; set; }
        public virtual DbSet<LogClear> LogClears { get; set; }
        public virtual DbSet<LogControl> LogControls { get; set; }
        public virtual DbSet<LogCopy> LogCopies { get; set; }
        public virtual DbSet<LogJob> LogJobs { get; set; }
        public virtual DbSet<LogMail> LogMails { get; set; }
        public virtual DbSet<LogPoint> LogPoints { get; set; }
        public virtual DbSet<LogRtsd> LogRtsds { get; set; }
        public virtual DbSet<LogRtsd2> LogRtsd2s { get; set; }
        public virtual DbSet<LogRtsd2015> LogRtsd2015s { get; set; }
        public virtual DbSet<LogRtsdCopy> LogRtsdCopies { get; set; }
        public virtual DbSet<LogService> LogServices { get; set; }
        public virtual DbSet<LogSession> LogSessions { get; set; }
        public virtual DbSet<LogSheduler> LogShedulers { get; set; }
        public virtual DbSet<LogSite> LogSites { get; set; }
        public virtual DbSet<LogVpn> LogVpns { get; set; }
        public virtual DbSet<Mac> Macs { get; set; }
        public virtual DbSet<MacVendor> MacVendors { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<OutGet> OutGets { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<PartnerCopy> PartnerCopies { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Point> Points { get; set; }
        public virtual DbSet<PointCopy> PointCopies { get; set; }
        public virtual DbSet<Rtsd> Rtsds { get; set; }
        public virtual DbSet<RtsdCopy> RtsdCopies { get; set; }
        public virtual DbSet<RtsdInUse> RtsdInUses { get; set; }
        public virtual DbSet<RtsdInUse2> RtsdInUse2s { get; set; }
        public virtual DbSet<RtsdInUseCopy> RtsdInUseCopies { get; set; }
        public virtual DbSet<SEARCH> SEARCHes { get; set; }
        public virtual DbSet<SETTING> SETTINGs { get; set; }
        public virtual DbSet<Setting1> Settings1 { get; set; }
        public virtual DbSet<Timer> Timers { get; set; }
        public virtual DbSet<ToLog> ToLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User1> Users1 { get; set; }
        public virtual DbSet<Users220917> Users220917s { get; set; }
        public virtual DbSet<Users290917> Users290917s { get; set; }
        public virtual DbSet<UsersCopy> UsersCopies { get; set; }
        public virtual DbSet<Vlan> Vlans { get; set; }
        public virtual DbSet<VpnWork> VpnWorks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = servicesrv; Database=Energo;User Id = milokum.test.user; Password=12345678;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Abc3x>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_ABC-3x");

                entity.Property(e => e.AbcDef)
                    .HasMaxLength(254)
                    .HasColumnName("abc_def");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.From)
                    .HasMaxLength(254)
                    .HasColumnName("from");

                entity.Property(e => e.Operators)
                    .HasMaxLength(254)
                    .HasColumnName("operators");

                entity.Property(e => e.Region)
                    .HasMaxLength(254)
                    .HasColumnName("region");

                entity.Property(e => e.To)
                    .HasMaxLength(254)
                    .HasColumnName("to");
            });

            modelBuilder.Entity<Abc4x>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_ABC-4x");

                entity.Property(e => e.AbcDef)
                    .HasMaxLength(254)
                    .HasColumnName("abc_def");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.From)
                    .HasMaxLength(254)
                    .HasColumnName("from");

                entity.Property(e => e.Operators)
                    .HasMaxLength(254)
                    .HasColumnName("operators");

                entity.Property(e => e.Region)
                    .HasMaxLength(254)
                    .HasColumnName("region");

                entity.Property(e => e.To)
                    .HasMaxLength(254)
                    .HasColumnName("to");
            });

            modelBuilder.Entity<Abc8x>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_ABC-8x");

                entity.Property(e => e.AbcDef)
                    .HasMaxLength(254)
                    .HasColumnName("abc_def");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.From)
                    .HasMaxLength(254)
                    .HasColumnName("from");

                entity.Property(e => e.Operators)
                    .HasMaxLength(254)
                    .HasColumnName("operators");

                entity.Property(e => e.Region)
                    .HasMaxLength(254)
                    .HasColumnName("region");

                entity.Property(e => e.To)
                    .HasMaxLength(254)
                    .HasColumnName("to");
            });

            modelBuilder.Entity<Ahtung>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ahtung");

                entity.Property(e => e.Date)
                    .HasMaxLength(10)
                    .HasColumnName("_date")
                    .IsFixedLength(true);

                entity.Property(e => e.Fio)
                    .HasMaxLength(60)
                    .HasColumnName("fio")
                    .IsFixedLength(true);

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .HasColumnName("id")
                    .IsFixedLength(true);

                entity.Property(e => e.Pol)
                    .HasMaxLength(3)
                    .HasColumnName("pol")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(8)
                    .HasColumnName("_time")
                    .IsFixedLength(true);

                entity.Property(e => e.Use)
                    .HasMaxLength(3)
                    .HasColumnName("_use")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<C>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK__cs__DF908D6545538E99");

                entity.ToTable("cs");

                entity.Property(e => e.Num)
                    .HasMaxLength(10)
                    .HasColumnName("num")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Apname)
                    .HasMaxLength(25)
                    .HasColumnName("APName")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Inuse).HasColumnName("inuse");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.MacL)
                    .HasMaxLength(17)
                    .HasColumnName("mac_l")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.MacW)
                    .HasMaxLength(17)
                    .HasColumnName("mac_w")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Nsik)
                    .HasMaxLength(50)
                    .HasColumnName("NSIK")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.ProductId)
                    .HasMaxLength(25)
                    .HasColumnName("ProductID")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Ser)
                    .HasMaxLength(30)
                    .HasColumnName("ser")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<CiscoVpn>(entity =>
            {
                entity.ToTable("cisco_vpn");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateIn)
                    .HasMaxLength(25)
                    .HasColumnName("date_in")
                    .IsFixedLength(true);

                entity.Property(e => e.DateOut)
                    .HasMaxLength(25)
                    .HasColumnName("date_out")
                    .IsFixedLength(true);

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .IsFixedLength(true);

                entity.Property(e => e.St).HasColumnName("st");

                entity.Property(e => e.User)
                    .HasMaxLength(35)
                    .HasColumnName("user")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("comment");

                entity.Property(e => e.Comment1)
                    .HasColumnType("ntext")
                    .HasColumnName("comment")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Postid)
                    .HasMaxLength(255)
                    .HasColumnName("postid")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Postnum)
                    .HasColumnName("postnum")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Computer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("computers");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .IsFixedLength(true);

                entity.Property(e => e.Mac)
                    .HasMaxLength(17)
                    .HasColumnName("mac")
                    .IsFixedLength(true);

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasColumnName("memo");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ComputersCopy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("computers_copy");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .IsFixedLength(true);

                entity.Property(e => e.Mac)
                    .HasMaxLength(17)
                    .HasColumnName("mac")
                    .IsFixedLength(true);

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasColumnName("memo");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("contacts");

                entity.Property(e => e.Adr)
                    .HasMaxLength(255)
                    .HasColumnName("adr")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Bday)
                    .HasMaxLength(255)
                    .HasColumnName("bday")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Fn)
                    .HasMaxLength(255)
                    .HasColumnName("fn")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.N)
                    .HasMaxLength(255)
                    .HasColumnName("n")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Org)
                    .HasMaxLength(255)
                    .HasColumnName("org")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Photo)
                    .HasColumnType("text")
                    .HasColumnName("photo")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Prodid)
                    .HasMaxLength(255)
                    .HasColumnName("prodid")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tel)
                    .HasMaxLength(255)
                    .HasColumnName("tel")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Uid)
                    .HasMaxLength(255)
                    .HasColumnName("uid")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .HasColumnName("version")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.XFileAs)
                    .HasMaxLength(255)
                    .HasColumnName("x_file_as")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ContactsDcenergoRu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("contacts_dcenergo.ru");

                entity.Property(e => e.Adr)
                    .HasMaxLength(255)
                    .HasColumnName("adr")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Bday)
                    .HasMaxLength(255)
                    .HasColumnName("bday")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Fn)
                    .HasMaxLength(255)
                    .HasColumnName("fn")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.N)
                    .HasMaxLength(255)
                    .HasColumnName("n")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Org)
                    .HasMaxLength(255)
                    .HasColumnName("org")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Photo)
                    .HasColumnType("text")
                    .HasColumnName("photo")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Prodid)
                    .HasMaxLength(255)
                    .HasColumnName("prodid")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tel)
                    .HasMaxLength(255)
                    .HasColumnName("tel")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Uid)
                    .HasMaxLength(255)
                    .HasColumnName("uid")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .HasColumnName("version")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.XFileAs)
                    .HasMaxLength(255)
                    .HasColumnName("x_file_as")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ContactsEnergospbRu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("contacts_energospb.ru");

                entity.Property(e => e.Adr)
                    .HasMaxLength(255)
                    .HasColumnName("adr")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Bday)
                    .HasMaxLength(255)
                    .HasColumnName("bday")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Fn)
                    .HasMaxLength(255)
                    .HasColumnName("fn")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.N)
                    .HasMaxLength(255)
                    .HasColumnName("n")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Org)
                    .HasMaxLength(255)
                    .HasColumnName("org")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Photo)
                    .HasColumnType("text")
                    .HasColumnName("photo")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Prodid)
                    .HasMaxLength(255)
                    .HasColumnName("prodid")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tel)
                    .HasMaxLength(255)
                    .HasColumnName("tel")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Uid)
                    .HasMaxLength(255)
                    .HasColumnName("uid")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .HasColumnName("version")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.XFileAs)
                    .HasMaxLength(255)
                    .HasColumnName("x_file_as")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ContactsTdenergospbRu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("contacts_tdenergospb.ru");

                entity.Property(e => e.Adr)
                    .HasMaxLength(255)
                    .HasColumnName("adr")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Bday)
                    .HasMaxLength(255)
                    .HasColumnName("bday")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Fn)
                    .HasMaxLength(255)
                    .HasColumnName("fn")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.N)
                    .HasMaxLength(255)
                    .HasColumnName("n")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Org)
                    .HasMaxLength(255)
                    .HasColumnName("org")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Photo)
                    .HasColumnType("text")
                    .HasColumnName("photo")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Prodid)
                    .HasMaxLength(255)
                    .HasColumnName("prodid")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tel)
                    .HasMaxLength(255)
                    .HasColumnName("tel")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Uid)
                    .HasMaxLength(255)
                    .HasColumnName("uid")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .HasColumnName("version")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.XFileAs)
                    .HasMaxLength(255)
                    .HasColumnName("x_file_as")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Control>(entity =>
            {
                entity.HasKey(e => e.N)
                    .HasName("PK__control___3BD0199338313C96");

                entity.ToTable("control");

                entity.Property(e => e.N).HasColumnName("n");

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .HasColumnName("color")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Controls)
                    .HasColumnType("text")
                    .HasColumnName("controls")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Inuse)
                    .HasColumnName("inuse")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .HasColumnName("name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Scheme)
                    .HasColumnName("scheme")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");
            });

            modelBuilder.Entity<ControlCopy>(entity =>
            {
                entity.HasKey(e => e.N)
                    .HasName("PK__control___3BD01993B64AB06A");

                entity.ToTable("control_copy");

                entity.Property(e => e.N).HasColumnName("n");

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .HasColumnName("color")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Controls)
                    .HasColumnType("text")
                    .HasColumnName("controls")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .HasColumnName("name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Scheme)
                    .HasColumnName("scheme")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");
            });

            modelBuilder.Entity<ControlCopyCopy>(entity =>
            {
                entity.HasKey(e => e.N)
                    .HasName("PK__control___3BD0199366C93718");

                entity.ToTable("control_copy_copy");

                entity.Property(e => e.N).HasColumnName("n");

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .HasColumnName("color")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Controls)
                    .HasColumnType("text")
                    .HasColumnName("controls")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .HasColumnName("name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Scheme)
                    .HasColumnName("scheme")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");
            });

            modelBuilder.Entity<Copy>(entity =>
            {
                entity.ToTable("copy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Patch)
                    .HasColumnType("text")
                    .HasColumnName("patch")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<CsCopy>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK__cs_copy__DF908D65B8011657");

                entity.ToTable("cs_copy");

                entity.Property(e => e.Num)
                    .HasMaxLength(10)
                    .HasColumnName("num")
                    .IsFixedLength(true);

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .IsFixedLength(true);

                entity.Property(e => e.MacL)
                    .HasMaxLength(17)
                    .HasColumnName("mac_l")
                    .IsFixedLength(true);

                entity.Property(e => e.MacW)
                    .HasMaxLength(17)
                    .HasColumnName("mac_w")
                    .IsFixedLength(true);

                entity.Property(e => e.Ser)
                    .HasMaxLength(30)
                    .HasColumnName("ser")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<CsCopyCopy>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK__cs_copy___DF908D650CF47F17");

                entity.ToTable("cs_copy_copy");

                entity.Property(e => e.Num)
                    .HasMaxLength(10)
                    .HasColumnName("num")
                    .IsFixedLength(true);

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .IsFixedLength(true);

                entity.Property(e => e.MacL)
                    .HasMaxLength(17)
                    .HasColumnName("mac_l")
                    .IsFixedLength(true);

                entity.Property(e => e.MacW)
                    .HasMaxLength(17)
                    .HasColumnName("mac_w")
                    .IsFixedLength(true);

                entity.Property(e => e.Ser)
                    .HasMaxLength(30)
                    .HasColumnName("ser")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Def9x>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("_DEF-9x");

                entity.Property(e => e.AbcDef)
                    .HasMaxLength(254)
                    .HasColumnName("abc_def");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.From)
                    .HasMaxLength(254)
                    .HasColumnName("from");

                entity.Property(e => e.Operators)
                    .HasMaxLength(254)
                    .HasColumnName("operators");

                entity.Property(e => e.Region)
                    .HasMaxLength(254)
                    .HasColumnName("region");

                entity.Property(e => e.To)
                    .HasMaxLength(254)
                    .HasColumnName("to");
            });

            modelBuilder.Entity<Def9xRu>(entity =>
            {
                entity.HasKey(e => e.N)
                    .HasName("PK__DEF-9xRU__3BD019933CC8FCA3");

                entity.ToTable("DEF-9xRUS");

                entity.Property(e => e.N).HasColumnName("n");

                entity.Property(e => e.AbcDef)
                    .HasMaxLength(255)
                    .HasColumnName("abc_def")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Capacity)
                    .HasColumnName("capacity")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.From)
                    .HasMaxLength(255)
                    .HasColumnName("from")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Operators)
                    .HasMaxLength(255)
                    .HasColumnName("operators")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.To)
                    .HasMaxLength(255)
                    .HasColumnName("to")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Def9xSpb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DEF-9xSPB");

                entity.Property(e => e.AbcDef)
                    .HasMaxLength(254)
                    .HasColumnName("abc_def");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.From)
                    .HasMaxLength(254)
                    .HasColumnName("from");

                entity.Property(e => e.Operators)
                    .HasMaxLength(254)
                    .HasColumnName("operators");

                entity.Property(e => e.To)
                    .HasMaxLength(254)
                    .HasColumnName("to");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Mac)
                    .HasName("PK__device__DF5071E7AAD1F558");

                entity.ToTable("device");

                entity.Property(e => e.Mac)
                    .HasMaxLength(12)
                    .HasColumnName("mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Device1)
                    .HasMaxLength(50)
                    .HasColumnName("device")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Sn)
                    .HasMaxLength(25)
                    .HasColumnName("sn")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Vendor)
                    .HasMaxLength(50)
                    .HasColumnName("vendor")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Dm>(entity =>
            {
                entity.ToTable("dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("_dt")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.FullPrint)
                    .HasMaxLength(15)
                    .HasColumnName("_full_print")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Hot)
                    .HasMaxLength(3)
                    .HasColumnName("_hot")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("_ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.LastHead)
                    .HasMaxLength(15)
                    .HasColumnName("_last_head")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mac)
                    .HasMaxLength(50)
                    .HasColumnName("_mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Sn)
                    .HasMaxLength(50)
                    .HasColumnName("_sn")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Fiz>(entity =>
            {
                entity.ToTable("fiz");

                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .HasColumnName("id")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.En)
                    .HasMaxLength(10)
                    .HasColumnName("en")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Fio)
                    .HasMaxLength(80)
                    .HasColumnName("fio")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SUser)
                    .HasMaxLength(1)
                    .HasColumnName("s_user")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Work)
                    .HasMaxLength(40)
                    .HasColumnName("work")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<FizCopy>(entity =>
            {
                entity.ToTable("fiz_copy");

                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .HasColumnName("id")
                    .IsFixedLength(true);

                entity.Property(e => e.En)
                    .HasMaxLength(10)
                    .HasColumnName("en")
                    .IsFixedLength(true);

                entity.Property(e => e.Fio)
                    .HasMaxLength(80)
                    .HasColumnName("fio")
                    .IsFixedLength(true);

                entity.Property(e => e.SUser)
                    .HasMaxLength(1)
                    .HasColumnName("s_user")
                    .IsFixedLength(true);

                entity.Property(e => e.Work)
                    .HasMaxLength(40)
                    .HasColumnName("work")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Freedisk>(entity =>
            {
                entity.HasKey(e => e.Npp)
                    .HasName("PK__freedisk__C7DE9A2C4B5A23FA");

                entity.ToTable("freedisk");

                entity.Property(e => e.Npp).HasColumnName("NPP");

                entity.Property(e => e.Capacity).HasDefaultValueSql("('')");

                entity.Property(e => e.DriveLetter)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("DT")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.FileSystem)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.FreeSpace).HasDefaultValueSql("('')");

                entity.Property(e => e.Server)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<FreediskCopy>(entity =>
            {
                entity.HasKey(e => e.Npp)
                    .HasName("PK__freedisk__C7DE9A2C89F7F355");

                entity.ToTable("freedisk_copy");

                entity.Property(e => e.Npp).HasColumnName("NPP");

                entity.Property(e => e.Capacity).HasDefaultValueSql("('')");

                entity.Property(e => e.DriveLetter)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("DT")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.FileSystem)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.FreeSpace).HasDefaultValueSql("('')");

                entity.Property(e => e.Server)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<GoVoIp>(entity =>
            {
                entity.HasKey(e => e.Npp)
                    .HasName("PK__GoVoIP__DF90E5D63BE820ED");

                entity.ToTable("GoVoIP");

                entity.Property(e => e.Npp).HasColumnName("npp");

                entity.Property(e => e.Beeline1)
                    .HasMaxLength(10)
                    .HasColumnName("beeline_1")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Beeline2)
                    .HasMaxLength(10)
                    .HasColumnName("beeline_2")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Dt)
                    .HasMaxLength(19)
                    .HasColumnName("dt")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Megafone1)
                    .HasMaxLength(10)
                    .HasColumnName("megafone_1")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Megafone2)
                    .HasMaxLength(10)
                    .HasColumnName("megafone_2")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mts1)
                    .HasMaxLength(10)
                    .HasColumnName("mts_1")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mts2)
                    .HasMaxLength(10)
                    .HasColumnName("mts_2")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tele21)
                    .HasMaxLength(10)
                    .HasColumnName("tele2_1")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tele22)
                    .HasMaxLength(10)
                    .HasColumnName("tele2_2")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<InGet>(entity =>
            {
                entity.ToTable("in_get");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CallId)
                    .HasMaxLength(25)
                    .HasColumnName("_call_id")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Datatime)
                    .HasMaxLength(25)
                    .HasColumnName("_datatime")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.DisplayLocal)
                    .HasMaxLength(50)
                    .HasColumnName("_display_local")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.DisplayRemote)
                    .HasMaxLength(50)
                    .HasColumnName("_display_remote")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Ip)
                    .HasMaxLength(25)
                    .HasColumnName("_ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Local)
                    .HasMaxLength(50)
                    .HasColumnName("_local")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mac)
                    .HasMaxLength(25)
                    .HasColumnName("_mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Remote)
                    .HasMaxLength(25)
                    .HasColumnName("_remote")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.Log1)
                    .HasColumnType("text")
                    .HasColumnName("log");

                entity.Property(e => e.Thread)
                    .HasColumnType("text")
                    .HasColumnName("thread");
            });

            modelBuilder.Entity<LogAdmin>(entity =>
            {
                entity.ToTable("log_admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log");
            });

            modelBuilder.Entity<LogAsterisk>(entity =>
            {
                entity.ToTable("log_asterisk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log");
            });

            modelBuilder.Entity<LogClear>(entity =>
            {
                entity.ToTable("log_clear");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log");
            });

            modelBuilder.Entity<LogControl>(entity =>
            {
                entity.HasKey(e => e.N)
                    .HasName("PK__control___3BD01993C05C7D4B");

                entity.ToTable("log_control");

                entity.Property(e => e.N).HasColumnName("n");

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .HasColumnName("color")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Controls)
                    .HasColumnType("text")
                    .HasColumnName("controls")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("_dt")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Enable)
                    .HasColumnName("enable")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .HasColumnName("name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Scheme)
                    .HasColumnName("scheme")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.User)
                    .HasMaxLength(50)
                    .HasColumnName("_user")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<LogCopy>(entity =>
            {
                entity.ToTable("log_copy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log");

                entity.Property(e => e.Thread)
                    .HasColumnType("text")
                    .HasColumnName("thread");
            });

            modelBuilder.Entity<LogJob>(entity =>
            {
                entity.ToTable("log_Job");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<LogMail>(entity =>
            {
                entity.ToTable("log_mail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log");
            });

            modelBuilder.Entity<LogPoint>(entity =>
            {
                entity.ToTable("log_point");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("_dt")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Enable)
                    .HasColumnName("enable")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FName)
                    .HasMaxLength(255)
                    .HasColumnName("f_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.IdIp)
                    .HasMaxLength(255)
                    .HasColumnName("id_ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.IdPhone)
                    .HasMaxLength(255)
                    .HasColumnName("id_phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.LName)
                    .HasMaxLength(255)
                    .HasColumnName("l_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Login)
                    .HasMaxLength(255)
                    .HasColumnName("login")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.MName)
                    .HasMaxLength(255)
                    .HasColumnName("m_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mac)
                    .HasMaxLength(17)
                    .HasColumnName("mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mail)
                    .HasMaxLength(255)
                    .HasColumnName("mail")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasColumnName("memo")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PbxPort)
                    .HasMaxLength(25)
                    .HasColumnName("pbx_port")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SocketIp)
                    .HasMaxLength(255)
                    .HasColumnName("socket_ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SocketPhone)
                    .HasMaxLength(255)
                    .HasColumnName("socket_phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SwitchName)
                    .HasMaxLength(255)
                    .HasColumnName("switch_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SwitchPort)
                    .HasMaxLength(255)
                    .HasColumnName("switch_port")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.User)
                    .HasMaxLength(50)
                    .HasColumnName("_user")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LogRtsd>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK__log_rtsd__DF908D65FBE5EE5F");

                entity.ToTable("log_rtsd");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Date)
                    .HasMaxLength(10)
                    .HasColumnName("_date")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Fio)
                    .HasMaxLength(60)
                    .HasColumnName("fio")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .HasColumnName("id")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(20)
                    .HasColumnName("_time")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tsd)
                    .HasMaxLength(20)
                    .HasColumnName("tsd")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.TsdUse)
                    .HasMaxLength(20)
                    .HasColumnName("tsd_use")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LogRtsd2>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK__log_rtsd__DF908D65DAA695AA");

                entity.ToTable("log_rtsd2");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Date)
                    .HasMaxLength(10)
                    .HasColumnName("_date")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Fio)
                    .HasMaxLength(60)
                    .HasColumnName("fio")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .HasColumnName("id")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(20)
                    .HasColumnName("_time")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tsd)
                    .HasMaxLength(20)
                    .HasColumnName("tsd")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.TsdUse)
                    .HasMaxLength(20)
                    .HasColumnName("tsd_use")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LogRtsd2015>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK__log_rtsd__DF908D658CCA82C4");

                entity.ToTable("log_rtsd_2015");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Date)
                    .HasMaxLength(10)
                    .HasColumnName("_date")
                    .IsFixedLength(true);

                entity.Property(e => e.Fio)
                    .HasMaxLength(60)
                    .HasColumnName("fio")
                    .IsFixedLength(true);

                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .HasColumnName("id")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(20)
                    .HasColumnName("_time")
                    .IsFixedLength(true);

                entity.Property(e => e.Tsd)
                    .HasMaxLength(20)
                    .HasColumnName("tsd")
                    .IsFixedLength(true);

                entity.Property(e => e.TsdUse)
                    .HasMaxLength(20)
                    .HasColumnName("tsd_use")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LogRtsdCopy>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK__log_rtsd__DF908D655CCB94CE");

                entity.ToTable("log_rtsd_copy");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Date)
                    .HasMaxLength(10)
                    .HasColumnName("_date")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Fio)
                    .HasMaxLength(60)
                    .HasColumnName("fio")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .HasColumnName("id")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(20)
                    .HasColumnName("_time")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tsd)
                    .HasMaxLength(20)
                    .HasColumnName("tsd")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.TsdUse)
                    .HasMaxLength(20)
                    .HasColumnName("tsd_use")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LogService>(entity =>
            {
                entity.ToTable("log_service");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log");
            });

            modelBuilder.Entity<LogSession>(entity =>
            {
                entity.ToTable("log_session");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log");
            });

            modelBuilder.Entity<LogSheduler>(entity =>
            {
                entity.ToTable("log_Sheduler");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log");
            });

            modelBuilder.Entity<LogSite>(entity =>
            {
                entity.ToTable("log_site");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log");
            });

            modelBuilder.Entity<LogVpn>(entity =>
            {
                entity.ToTable("log_vpn");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log");
            });

            modelBuilder.Entity<Mac>(entity =>
            {
                entity.HasKey(e => e.Mac1)
                    .HasName("PK__mac__DF5071E7C5BBAF59");

                entity.ToTable("mac");

                entity.Property(e => e.Mac1)
                    .HasMaxLength(17)
                    .HasColumnName("mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MacVendor>(entity =>
            {
                entity.HasKey(e => e.Mac)
                    .HasName("PK__mac_vend__CFF66C9EB714B62C");

                entity.ToTable("mac_vendor");

                entity.Property(e => e.Mac)
                    .HasMaxLength(6)
                    .HasColumnName("_mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Vendor)
                    .HasMaxLength(255)
                    .HasColumnName("_vendor")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("_id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("_content");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("_data");

                entity.Property(e => e.Title)
                    .HasColumnType("text")
                    .HasColumnName("_title");
            });

            modelBuilder.Entity<OutGet>(entity =>
            {
                entity.ToTable("out_get");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CallId)
                    .HasMaxLength(25)
                    .HasColumnName("_call_id")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Datatime)
                    .HasMaxLength(25)
                    .HasColumnName("_datatime")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.DisplayLocal)
                    .HasMaxLength(50)
                    .HasColumnName("_display_local")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.DisplayRemote)
                    .HasMaxLength(50)
                    .HasColumnName("_display_remote")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Ip)
                    .HasMaxLength(25)
                    .HasColumnName("_ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Local)
                    .HasMaxLength(50)
                    .HasColumnName("_local")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mac)
                    .HasMaxLength(25)
                    .HasColumnName("_mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Remote)
                    .HasMaxLength(25)
                    .HasColumnName("_remote")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("partner");

                entity.Property(e => e.Addr)
                    .HasMaxLength(100)
                    .HasColumnName("addr")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mail)
                    .HasMaxLength(25)
                    .HasColumnName("mail")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(15)
                    .HasColumnName("mobile")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Site)
                    .HasMaxLength(25)
                    .HasColumnName("site")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tel)
                    .HasMaxLength(15)
                    .HasColumnName("tel")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.User)
                    .HasMaxLength(50)
                    .HasColumnName("user")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PartnerCopy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("partner_copy");

                entity.Property(e => e.Addr)
                    .HasMaxLength(100)
                    .HasColumnName("addr")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mail)
                    .HasMaxLength(25)
                    .HasColumnName("mail")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(15)
                    .HasColumnName("mobile")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Site)
                    .HasMaxLength(25)
                    .HasColumnName("site")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tel)
                    .HasMaxLength(15)
                    .HasColumnName("tel")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.User)
                    .HasMaxLength(50)
                    .HasColumnName("user")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdName)
                    .HasMaxLength(255)
                    .HasColumnName("ad_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Enable)
                    .HasColumnName("enable")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Mail)
                    .HasMaxLength(255)
                    .HasColumnName("mail")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.P2)
                    .HasMaxLength(255)
                    .HasColumnName("p2")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.P3)
                    .HasMaxLength(255)
                    .HasColumnName("p3")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone1)
                    .HasMaxLength(4)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Photo)
                    .HasMaxLength(255)
                    .HasColumnName("photo")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Point>(entity =>
            {
                entity.ToTable("point");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.FName)
                    .HasMaxLength(255)
                    .HasColumnName("f_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.IdIp)
                    .HasMaxLength(255)
                    .HasColumnName("id_ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.IdPhone)
                    .HasMaxLength(255)
                    .HasColumnName("id_phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.LName)
                    .HasMaxLength(255)
                    .HasColumnName("l_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Locate)
                    .HasMaxLength(255)
                    .HasColumnName("locate")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Login)
                    .HasMaxLength(255)
                    .HasColumnName("login")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.MName)
                    .HasMaxLength(255)
                    .HasColumnName("m_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mac)
                    .HasMaxLength(17)
                    .HasColumnName("mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mail)
                    .HasMaxLength(255)
                    .HasColumnName("mail")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasColumnName("memo")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PbxPort)
                    .HasMaxLength(25)
                    .HasColumnName("pbx_port")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SocketIp)
                    .HasMaxLength(255)
                    .HasColumnName("socket_ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SocketPhone)
                    .HasMaxLength(255)
                    .HasColumnName("socket_phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SwitchName)
                    .HasMaxLength(255)
                    .HasColumnName("switch_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SwitchPort)
                    .HasMaxLength(255)
                    .HasColumnName("switch_port")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PointCopy>(entity =>
            {
                entity.ToTable("point_copy");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.FName)
                    .HasMaxLength(255)
                    .HasColumnName("f_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.IdIp)
                    .HasMaxLength(255)
                    .HasColumnName("id_ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.IdPhone)
                    .HasMaxLength(255)
                    .HasColumnName("id_phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.LName)
                    .HasMaxLength(255)
                    .HasColumnName("l_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Locate)
                    .HasMaxLength(255)
                    .HasColumnName("locate")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Login)
                    .HasMaxLength(255)
                    .HasColumnName("login")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.MName)
                    .HasMaxLength(255)
                    .HasColumnName("m_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mac)
                    .HasMaxLength(17)
                    .HasColumnName("mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mail)
                    .HasMaxLength(255)
                    .HasColumnName("mail")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasColumnName("memo")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PbxPort)
                    .HasMaxLength(25)
                    .HasColumnName("pbx_port")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SocketIp)
                    .HasMaxLength(255)
                    .HasColumnName("socket_ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SocketPhone)
                    .HasMaxLength(255)
                    .HasColumnName("socket_phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SwitchName)
                    .HasMaxLength(255)
                    .HasColumnName("switch_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.SwitchPort)
                    .HasMaxLength(255)
                    .HasColumnName("switch_port")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Rtsd>(entity =>
            {
                entity.HasKey(e => new { e.Tsd, e.Ser, e.Mac, e.Inv })
                    .HasName("PK__rtsd__DC10E8D4D4FA0C20");

                entity.ToTable("rtsd");

                entity.Property(e => e.Tsd)
                    .HasMaxLength(3)
                    .HasColumnName("tsd")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Ser)
                    .HasMaxLength(20)
                    .HasColumnName("ser")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mac)
                    .HasMaxLength(17)
                    .HasColumnName("mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Inv)
                    .HasMaxLength(10)
                    .HasColumnName("inv")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasColumnName("memo")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.St)
                    .HasMaxLength(1)
                    .HasColumnName("st")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.WmsMac)
                    .HasMaxLength(25)
                    .HasColumnName("wms_mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RtsdCopy>(entity =>
            {
                entity.HasKey(e => new { e.Tsd, e.Ser, e.Mac, e.Inv })
                    .HasName("PK__rtsd_cop__9AAF86614467D9D4");

                entity.ToTable("rtsd_copy");

                entity.Property(e => e.Tsd)
                    .HasMaxLength(3)
                    .HasColumnName("tsd")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Ser)
                    .HasMaxLength(20)
                    .HasColumnName("ser")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Mac)
                    .HasMaxLength(17)
                    .HasColumnName("mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Inv)
                    .HasMaxLength(10)
                    .HasColumnName("inv")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasColumnName("memo")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.St)
                    .HasMaxLength(1)
                    .HasColumnName("st")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.WmsMac)
                    .HasMaxLength(25)
                    .HasColumnName("wms_mac")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RtsdInUse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rtsd_in_use");

                entity.Property(e => e.DS)
                    .HasMaxLength(20)
                    .HasColumnName("d_s")
                    .IsFixedLength(true);

                entity.Property(e => e.DV)
                    .HasMaxLength(20)
                    .HasColumnName("d_v")
                    .IsFixedLength(true);

                entity.Property(e => e.Fio)
                    .HasMaxLength(80)
                    .HasColumnName("fio")
                    .IsFixedLength(true);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("id")
                    .IsFixedLength(true);

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasColumnName("memo");

                entity.Property(e => e.Rtsd)
                    .HasMaxLength(3)
                    .HasColumnName("rtsd")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.TsdInUse)
                    .HasMaxLength(5)
                    .HasColumnName("tsd_in_use")
                    .IsFixedLength(true);

                entity.Property(e => e.UsP)
                    .HasMaxLength(35)
                    .HasColumnName("us_p")
                    .IsFixedLength(true);

                entity.Property(e => e.UsV)
                    .HasMaxLength(35)
                    .HasColumnName("us_v")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RtsdInUse2>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK__rtsd_in___DF908D650622A997");

                entity.ToTable("rtsd_in_use2");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.DS)
                    .HasMaxLength(20)
                    .HasColumnName("d_s")
                    .IsFixedLength(true);

                entity.Property(e => e.DV)
                    .HasMaxLength(20)
                    .HasColumnName("d_v")
                    .IsFixedLength(true);

                entity.Property(e => e.Fio)
                    .HasMaxLength(80)
                    .HasColumnName("fio")
                    .IsFixedLength(true);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("id")
                    .IsFixedLength(true);

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasColumnName("memo");

                entity.Property(e => e.Rtsd)
                    .HasMaxLength(3)
                    .HasColumnName("rtsd")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.TsdInUse)
                    .HasMaxLength(5)
                    .HasColumnName("tsd_in_use")
                    .IsFixedLength(true);

                entity.Property(e => e.UsP)
                    .HasMaxLength(35)
                    .HasColumnName("us_p")
                    .IsFixedLength(true);

                entity.Property(e => e.UsV)
                    .HasMaxLength(35)
                    .HasColumnName("us_v")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RtsdInUseCopy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rtsd_in_use_copy");

                entity.Property(e => e.DS)
                    .HasMaxLength(20)
                    .HasColumnName("d_s")
                    .IsFixedLength(true);

                entity.Property(e => e.DV)
                    .HasMaxLength(20)
                    .HasColumnName("d_v")
                    .IsFixedLength(true);

                entity.Property(e => e.Fio)
                    .HasMaxLength(80)
                    .HasColumnName("fio")
                    .IsFixedLength(true);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("id")
                    .IsFixedLength(true);

                entity.Property(e => e.Memo)
                    .HasColumnType("text")
                    .HasColumnName("memo");

                entity.Property(e => e.Rtsd)
                    .HasMaxLength(3)
                    .HasColumnName("rtsd")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.TsdInUse)
                    .HasMaxLength(5)
                    .HasColumnName("tsd_in_use")
                    .IsFixedLength(true);

                entity.Property(e => e.UsP)
                    .HasMaxLength(35)
                    .HasColumnName("us_p")
                    .IsFixedLength(true);

                entity.Property(e => e.UsV)
                    .HasMaxLength(35)
                    .HasColumnName("us_v")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<SEARCH>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("s_e_a_r_c_h");

                entity.Property(e => e.P1)
                    .HasMaxLength(50)
                    .HasColumnName("p1")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.P2)
                    .HasMaxLength(50)
                    .HasColumnName("p2")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.P3)
                    .HasMaxLength(50)
                    .HasColumnName("p3")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.P4)
                    .HasMaxLength(50)
                    .HasColumnName("p4")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.P5)
                    .HasMaxLength(50)
                    .HasColumnName("p5")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<SETTING>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("s_e_t_t_i_n_g");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Setting1)
                    .HasColumnType("text")
                    .HasColumnName("setting")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Setting1>(entity =>
            {
                entity.ToTable("setting");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.WorkError).HasColumnName("work_error");

                entity.Property(e => e.WorkOk).HasColumnName("work_ok");
            });

            modelBuilder.Entity<Timer>(entity =>
            {
                entity.ToTable("timer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Hh).HasColumnName("_hh");

                entity.Property(e => e.Mm).HasColumnName("_mm");

                entity.Property(e => e.Run)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("_run")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ToLog>(entity =>
            {
                entity.ToTable("to_log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__user__72E12F1AC557E698");

                entity.ToTable("user");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("ip")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MtsNum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("mts_num")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Room)
                    .HasMaxLength(10)
                    .HasColumnName("room")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SamsungNum)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("samsung_num")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("user_name")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<User1>(entity =>
            {
                entity.HasKey(e => e.DcName)
                    .HasName("PK__users__11E0288325D6D7F5");

                entity.ToTable("users");

                entity.Property(e => e.DcName)
                    .HasMaxLength(50)
                    .HasColumnName("dc_name")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fio)
                    .HasMaxLength(50)
                    .HasColumnName("fio")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IpPhone)
                    .HasMaxLength(15)
                    .HasColumnName("ip_phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(7)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.UD)
                    .HasColumnName("u_d")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Users220917>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("users_22_09_17");

                entity.Property(e => e.DcName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dc_name");

                entity.Property(e => e.Fio)
                    .HasMaxLength(50)
                    .HasColumnName("fio");

                entity.Property(e => e.IpPhone)
                    .HasMaxLength(15)
                    .HasColumnName("ip_phone")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(7)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.UD).HasColumnName("u_d");
            });

            modelBuilder.Entity<Users290917>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("users_29_09_17");

                entity.Property(e => e.DcName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dc_name");

                entity.Property(e => e.Fio)
                    .HasMaxLength(50)
                    .HasColumnName("fio");

                entity.Property(e => e.IpPhone)
                    .HasMaxLength(15)
                    .HasColumnName("ip_phone")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(7)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.UD).HasColumnName("u_d");
            });

            modelBuilder.Entity<UsersCopy>(entity =>
            {
                entity.HasKey(e => e.DcName)
                    .HasName("PK__users_co__11E028836775B66A");

                entity.ToTable("users_copy");

                entity.Property(e => e.DcName)
                    .HasMaxLength(50)
                    .HasColumnName("dc_name")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fio)
                    .HasMaxLength(50)
                    .HasColumnName("fio")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IpPhone)
                    .HasMaxLength(15)
                    .HasColumnName("ip_phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(7)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.UD)
                    .HasColumnName("u_d")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Vlan>(entity =>
            {
                entity.HasKey(e => e.Vlan1)
                    .HasName("PK__vlan__76275E8A20DB9B01");

                entity.ToTable("vlan");

                entity.Property(e => e.Vlan1)
                    .HasMaxLength(4)
                    .HasColumnName("vlan")
                    .IsFixedLength(true);

                entity.Property(e => e.AccessBc)
                    .HasColumnName("access_bc")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccessDc)
                    .HasColumnName("access_dc")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IpLan)
                    .HasMaxLength(15)
                    .HasColumnName("ip_lan")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.VlanName)
                    .HasMaxLength(255)
                    .HasColumnName("vlan_name")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<VpnWork>(entity =>
            {
                entity.ToTable("vpn_work");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasMaxLength(25)
                    .HasColumnName("dt")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log")
                    .HasDefaultValueSql("('')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
