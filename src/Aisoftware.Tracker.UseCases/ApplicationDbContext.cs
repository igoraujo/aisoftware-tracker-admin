
using Microsoft.EntityFrameworkCore;
using System;
using Aisoftware.Tracker.Borders;
using System.Data;
using Npgsql;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.IO;
using Aisoftware.Tracker.Borders.ViewModels;

namespace Aisoftware.Tracker.UseCases
{
    public class ApplicationDbContext : DbContext
    {
        private string _connectionString;
        private NpgsqlConnection _conn;
        private DbConnection _dbconn;
        private IOptions<Config> _config;

        public NpgsqlConnection NpgsqlConnection
        {
            get
            {
                if (_conn == null)
                {
                    _conn = new NpgsqlConnection(_connectionString);
                }

                return _conn;
            }
        }

        public ApplicationDbContext()
        {
            if (_connectionString == null)
                _connectionString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString()), "conn.txt"));
        }

        #region Entidades do banco
        public DbSet<Balance> balance { get; set; }
        public DbSet<Car> car { get; set; }
        public DbSet<CarType> cartype { get; set; }
        public DbSet<City> city { get; set; }
        public DbSet<Company> company { get; set; }
        public DbSet<CompanyHistory> companyhistory { get; set; }
        public DbSet<Country> country { get; set; }
        public DbSet<Driver> driver { get; set; }
        public DbSet<Line> line { get; set; }
        public DbSet<LineCar> linecar { get; set; }
        public DbSet<LineCarHistory> linecarhistory { get; set; }
        public DbSet<LineHistory> linehistory { get; set; }
        public DbSet<Passenger> passenger { get; set; }
        public DbSet<Profile> profile { get; set; }
        public DbSet<QrCode> qrcoode { get; set; }
        public DbSet<State> state { get; set; }
        public DbSet<Ticket> ticket { get; set; }
        public DbSet<TicketHistory> tickethistory { get; set; }
        public DbSet<Travel> travel { get; set; }
        public DbSet<TravelPassenger> travelpassenger { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<UserHistory> userHistory { get; set; }
        #endregion

        #region Sem relação com entidades do banco
        internal virtual DbSet<ActiveTravelsPerDay> ActiveTravelsPerDay { get; set; }
        #endregion


        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        //    base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!string.IsNullOrEmpty(_config?.Value.UserIP))
            //    if (_connectionString.ToLower().Contains("dev_") && (_config.Value.UserIP != "::1" && _config.Value.UserIP != "127.0.0.1" && _config.Value.UserIP != "localhost"))
            //        throw new Exception("Acesso ao DB não permitido pela via em execução.");

            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Balance>(b =>
            {
                b.HasKey(x => x.ID);
            });

            modelBuilder.Entity<Car>(b =>
            {
                b.HasKey(x => x.ID);
            });

            modelBuilder.Entity<CarType>(b =>
            {
                b.HasKey(x => x.ID);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<CompanyHistory>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<Line>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<LineCar>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<LineCarHistory>(entity =>
            {
                entity.HasKey(e => e.ID);

            });

            modelBuilder.Entity<LineHistory>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.ID);

            });

            modelBuilder.Entity<QrCode>(entity =>
            {
                entity.HasKey(e => e.ID);

            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.ID);

            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<TicketHistory>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<Travel>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<TravelPassenger>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<UserHistory>(entity =>
            {
                entity.HasKey(e => e.ID);
            });
        }

        public object ExecuteScalar(string sql)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                        if (reader.Read())
                            return (reader[0]);
                }
            }
            return null;
        }

        public async Task ExecuteNonQueryAsync(string sql)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    cmd.CommandText = sql;
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public void ExecuteNonQuery(string sql)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public NpgsqlDataReader ExecuteReader(string sql, NpgsqlConnection conn)
        {
            using (var cmd = conn.CreateCommand())
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                cmd.CommandText = sql;
                return cmd.ExecuteReader();
            }
        }

        public NpgsqlDataReader ExecuteReader(string sql)
        {
            if (_dbconn == null)
                _dbconn = this.Database.GetDbConnection();

            using (var cmd = _dbconn.CreateCommand())
            {
                if (_dbconn.State != ConnectionState.Open)
                    _dbconn.Open();
                cmd.CommandText = sql;
                return (NpgsqlDataReader)cmd.ExecuteReader();
            }
        }

        public DataTable ExecuteDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(_connectionString))
            {

                using (var cmd = conn.CreateCommand())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                        if (reader != null)
                        {
                            dt.Load(reader);
                            return dt;
                        }
                }
            }
            return null;
        }

        public DataTable ExecuteDataTable(string sql, NpgsqlConnection conn)
        {
            DataTable dt = new DataTable();
            using (var cmd = conn.CreateCommand())
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                cmd.CommandText = sql;
                using (var reader = cmd.ExecuteReader())
                    if (reader != null)
                    {
                        dt.Load(reader);
                        return dt;
                    }
            }
            return null;
        }

        public override void Dispose()
        {
            base.Dispose();

            if (_conn != null)
                _conn.Dispose();
        }
    }
}
