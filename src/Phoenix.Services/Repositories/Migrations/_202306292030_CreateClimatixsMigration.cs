using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Devices;
using Phoenix.Entities.Plcs.Climatixs;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(_202306292030_CreateClimatixsMigration))]
   internal sealed class _202306292030_CreateClimatixsMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(Climatix),
            columns: table => new
            {
               Date = table.Column<DateTime>(name: nameof(Climatix.Date)),
               DeviceId = table.Column<int>(name: nameof(Climatix.DeviceId)),

               OutsideTemp = table.Column<float>(name: nameof(Climatix.OutsideTemp), defaultValue: default(float)),
               ChHighInletPresure = table.Column<float>(name: nameof(Climatix.ChHighInletPresure), defaultValue: default(float)),
               ChHighOutletPresure = table.Column<float>(name: nameof(Climatix.ChHighOutletPresure), defaultValue: default(float)),
               Alarm = table.Column<bool>(name: nameof(Climatix.Alarm), defaultValue: default(bool)),

               Ch1LowInletTemp = table.Column<float>(name: nameof(Climatix.Ch1LowInletTemp), defaultValue: default(float)),
               Ch1LowOutletTemp = table.Column<float>(name: nameof(Climatix.Ch1LowOutletTemp), defaultValue: default(float)),
               Ch1LowOutletPresure = table.Column<float>(name: nameof(Climatix.Ch1LowOutletPresure), defaultValue: default(float)),
               Ch1HeatCurveTemp = table.Column<float>(name: nameof(Climatix.Ch1HeatCurveTemp), defaultValue: default(float)),
               Ch1PumpAlarm = table.Column<bool>(name: nameof(Climatix.Ch1PumpAlarm), defaultValue: default(bool)),
               Ch1PumpStatus = table.Column<bool>(name: nameof(Climatix.Ch1PumpStatus), defaultValue: default(bool)),
               Ch1ValvePosition = table.Column<byte>(name: nameof(Climatix.Ch1ValvePosition), defaultValue: default(byte)),
               Ch1Status = table.Column<bool>(name: nameof(Climatix.Ch1Status), defaultValue: default(bool)),

               Ch2LowInletTemp = table.Column<float>(name: nameof(Climatix.Ch2LowInletTemp), defaultValue: default(float)),
               Ch2LowOutletTemp = table.Column<float>(name: nameof(Climatix.Ch2LowOutletTemp), defaultValue: default(float)),
               Ch2LowOutletPresure = table.Column<float>(name: nameof(Climatix.Ch2LowOutletPresure), defaultValue: default(float)),
               Ch2HeatCurveTemp = table.Column<float>(name: nameof(Climatix.Ch2HeatCurveTemp), defaultValue: default(float)),
               Ch2PumpAlarm = table.Column<bool>(name: nameof(Climatix.Ch2PumpAlarm), defaultValue: default(bool)),
               Ch2PumpStatus = table.Column<bool>(name: nameof(Climatix.Ch2PumpStatus), defaultValue: default(bool)),
               Ch2ValvePosition = table.Column<byte>(name: nameof(Climatix.Ch2ValvePosition), defaultValue: default(byte)),
               Ch2Status = table.Column<bool>(name: nameof(Climatix.Ch2Status), defaultValue: default(bool)),

               DhwTemp = table.Column<float>(name: nameof(Climatix.DhwTemp), defaultValue: default(float)),
               DhwTempSet = table.Column<float>(name: nameof(Climatix.DhwTempSet), defaultValue: default(float)),
               DhwPumpAlarm = table.Column<bool>(name: nameof(Climatix.DhwPumpAlarm), defaultValue: default(bool)),
               DhwPumpStatus = table.Column<bool>(name: nameof(Climatix.DhwPumpStatus), defaultValue: default(bool)),
               DhwValvePosition = table.Column<byte>(name: nameof(Climatix.DhwValvePosition), defaultValue: default(byte)),
               DhwStatus = table.Column<bool>(name: nameof(Climatix.DhwStatus), defaultValue: default(bool)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(Climatix)}_{nameof(Climatix.Date)}_{nameof(Climatix.Device)}", x => new { x.Date, x.DeviceId });
               table.ForeignKey($"FK_{nameof(Climatix)}_{nameof(Climatix.Device)}", x => x.DeviceId, nameof(Device), principalColumn: nameof(Device.Id));
            }
         );

         migrationBuilder.AddTableCompression(nameof(Climatix));
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(Climatix));
      }
   }
}
