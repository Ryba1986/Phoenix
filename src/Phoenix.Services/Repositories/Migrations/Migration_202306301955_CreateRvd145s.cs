using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Devices;
using Phoenix.Entities.Plcs.Rvds;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(Migration_202306301955_CreateRvd145s))]
   internal sealed class Migration_202306301955_CreateRvd145s : MigrationBase
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(Rvd145),
            columns: table => new
            {
               Date = table.Column<DateTime>(name: nameof(Rvd145.Date), precision: 0),
               DeviceId = table.Column<int>(name: nameof(Rvd145.DeviceId)),

               OutsideTemp = table.Column<float>(name: nameof(Rvd145.OutsideTemp), defaultValue: default(float)),
               ChHighInletPresure = table.Column<float>(name: nameof(Rvd145.ChHighInletPresure), defaultValue: default(float)),
               Alarm = table.Column<short>(name: nameof(Rvd145.Alarm), defaultValue: default(short)),

               Ch1HighOutletTemp = table.Column<float>(name: nameof(Rvd145.Ch1HighOutletTemp), defaultValue: default(float)),
               Ch1LowInletTemp = table.Column<float>(name: nameof(Rvd145.Ch1LowInletTemp), defaultValue: default(float)),
               Ch1LowOutletPresure = table.Column<float>(name: nameof(Rvd145.Ch1LowOutletPresure), defaultValue: default(float)),
               Ch1HeatCurveTemp = table.Column<float>(name: nameof(Rvd145.Ch1HeatCurveTemp), defaultValue: default(float)),
               Ch1PumpStatus = table.Column<bool>(name: nameof(Rvd145.Ch1PumpStatus), defaultValue: default(bool)),
               Ch1Status = table.Column<bool>(name: nameof(Rvd145.Ch1Status), defaultValue: default(bool)),

               DhwTemp = table.Column<float>(name: nameof(Rvd145.DhwTemp), defaultValue: default(float)),
               DhwTempSet = table.Column<float>(name: nameof(Rvd145.DhwTempSet), defaultValue: default(float)),
               DhwCirculationTemp = table.Column<float>(name: nameof(Rvd145.DhwCirculationTemp), defaultValue: default(float)),
               DhwPumpStatus = table.Column<bool>(name: nameof(Rvd145.DhwPumpStatus), defaultValue: default(bool)),
               DhwStatus = table.Column<bool>(name: nameof(Rvd145.DhwStatus), defaultValue: default(bool)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(Rvd145)}_{nameof(Rvd145.Date)}_{nameof(Rvd145.Device)}", x => new { x.Date, x.DeviceId });
               table.ForeignKey($"FK_{nameof(Rvd145)}_{nameof(Rvd145.Device)}", x => x.DeviceId, principalTable: nameof(Device), principalColumn: nameof(Device.Id));
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(Rvd145));
      }
   }
}
