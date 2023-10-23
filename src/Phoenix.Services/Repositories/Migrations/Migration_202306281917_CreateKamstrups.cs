using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Devices;
using Phoenix.Entities.Plcs.Meters;
using Phoenix.Services.Repositories.Migrations.Base;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(Migration_202306281917_CreateKamstrups))]
   internal sealed class Migration_202306281917_CreateKamstrups : MigrationBase
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(Kamstrup),
            columns: table => new
            {
               Date = table.Column<DateTime>(name: nameof(Kamstrup.Date), precision: 0),
               DeviceId = table.Column<int>(name: nameof(Kamstrup.DeviceId)),

               InletTemp = table.Column<float>(name: nameof(Kamstrup.InletTemp), defaultValue: default(float)),
               OutletTemp = table.Column<float>(name: nameof(Kamstrup.OutletTemp), defaultValue: default(float)),
               Power = table.Column<float>(name: nameof(Kamstrup.Power), defaultValue: default(float)),
               Volume = table.Column<float>(name: nameof(Kamstrup.Volume), defaultValue: default(float)),
               VolumeSummary = table.Column<float>(name: nameof(Kamstrup.VolumeSummary), defaultValue: default(float)),
               EnergySummary = table.Column<float>(name: nameof(Kamstrup.EnergySummary), defaultValue: default(float)),
               HourCount = table.Column<int>(name: nameof(Kamstrup.HourCount), defaultValue: default(int)),
               ErrorCode = table.Column<short>(name: nameof(Kamstrup.ErrorCode), defaultValue: default(short)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(Kamstrup)}_{nameof(Kamstrup.Date)}_{nameof(Kamstrup.Device)}", x => new { x.Date, x.DeviceId });
               table.ForeignKey($"FK_{nameof(Kamstrup)}_{nameof(Kamstrup.Device)}", x => x.DeviceId, principalTable: nameof(Device), principalColumn: nameof(Device.Id));
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(Kamstrup));
      }
   }
}
