﻿using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data
{
    public class FermentabuoyLogDataProvider : IFermentabuoyLogDataProvider
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public FermentabuoyLogDataProvider(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// This method receives a FermentationLog entity from the servcie and inserts the data into the SQLite DB
        /// </summary>
        /// <param name="log"> The Entity that is received from the service</param>
        /// <returns></returns>
        public async Task AddFermentabuoyLog(FermentabuoyLog log) 
        {            
            string sql = "Insert into FermentationLog (Name, Temperature, Gravity, Angle, DeviceId, Battery, RSSI) VALUES (@Name, @Temperature, @Gravity, @Angle, @DeviceId, @Battery, @RSSI);";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, log);
            }
            
        }

        /// <summary>
        /// Retrieves a Log entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FermentabuoyLog> GetLog(int id)
        {
            FermentabuoyLog log = new FermentabuoyLog();
            string sql = @"Select * from FermentationLog where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                log = await db.QueryFirstAsync<FermentabuoyLog>(sql, new { Id = id });
            }
            return log;
        }

        /// <summary>
        /// Retrieves all log entities from the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<FermentabuoyLog>> GetAllLogs()
        {
            string sql = @"Select
                            Id,
                            Name,
                            CAST(Temperature as REAL) as Temperature,
                            CAST(Gravity as REAL) as Gravity,
                            CAST(Angle as REAL) as Angle,
                            DeviceId,
                            CAST(Battery as REAL) as Battery,
                            RSSI,
                            Created
                            from FermentationLog;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                IEnumerable<FermentabuoyLog> logs = await db.QueryAsync<FermentabuoyLog>(sql);
                return logs.ToList();
            }
        }


    }
}
