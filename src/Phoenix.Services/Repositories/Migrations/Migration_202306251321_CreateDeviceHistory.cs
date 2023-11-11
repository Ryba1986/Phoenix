using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Devices;
using Phoenix.Entities.Locations;
using Phoenix.Entities.Users;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;
using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(Migration_202306251321_CreateDeviceHistory))]
   internal sealed class Migration_202306251321_CreateDeviceHistory : MigrationBase
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(DeviceHistory),
            columns: table => new
            {
               Id = table.Column<int>(name: nameof(DeviceHistory.Id)).AddIdentity(),
               DeviceId = table.Column<int>(name: nameof(DeviceHistory.DeviceId)),
               LocationId = table.Column<int>(name: nameof(DeviceHistory.LocationId), nullable: true),
               Name = table.Column<string>(name: nameof(DeviceHistory.Name), maxLength: 30, defaultValue: string.Empty),
               PlcType = table.Column<PlcType>(name: nameof(DeviceHistory.PlcType), nullable: true),
               ModbusId = table.Column<byte>(name: nameof(DeviceHistory.ModbusId), nullable: true),
               BoundRate = table.Column<SerialBoundRate>(name: nameof(DeviceHistory.BoundRate), nullable: true),
               DataBits = table.Column<SerialDataBits>(name: nameof(DeviceHistory.DataBits), nullable: true),
               Parity = table.Column<SerialParity>(name: nameof(DeviceHistory.Parity), nullable: true),
               StopBits = table.Column<SerialStopBits>(name: nameof(DeviceHistory.StopBits), nullable: true),
               SerialNumber = table.Column<string>(name: nameof(DeviceHistory.SerialNumber), maxLength: 20, defaultValue: string.Empty),
               Sequence = table.Column<byte>(name: nameof(Device.Sequence), nullable: true),
               IncludeReport = table.Column<bool>(name: nameof(DeviceHistory.IncludeReport), defaultValue: default(bool)),
               IsActive = table.Column<bool>(name: nameof(DeviceHistory.IsActive), defaultValue: default(bool)),
               CreatedById = table.Column<int>(name: nameof(DeviceHistory.CreatedById)),
               CreateDate = table.Column<DateTime>(name: nameof(DeviceHistory.CreateDate), precision: 0, defaultValue: default(DateTime)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(DeviceHistory)}_{nameof(DeviceHistory.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(DeviceHistory)}_{nameof(DeviceHistory.Device)}", x => x.DeviceId, principalTable: nameof(Device), principalColumn: nameof(Device.Id));
               table.ForeignKey($"FK_{nameof(DeviceHistory)}_{nameof(DeviceHistory.Location)}", x => x.LocationId, principalTable: nameof(Location), principalColumn: nameof(Location.Id));
               table.ForeignKey($"FK_{nameof(DeviceHistory)}_{nameof(DeviceHistory.CreatedBy)}", x => x.CreatedById, principalTable: nameof(User), principalColumn: nameof(User.Id));
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(DeviceHistory));
      }
   }
}
