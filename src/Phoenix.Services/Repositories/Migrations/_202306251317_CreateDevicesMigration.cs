using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Devices;
using Phoenix.Entities.Locations;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;
using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(_202306251317_CreateDevicesMigration))]
   internal sealed class _202306251317_CreateDevicesMigration : DbMigration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
            name: nameof(Device),
            columns: table => new
            {
               Id = table.Column<int>(name: nameof(Device.Id)).AddIdentity(),
               LocationId = table.Column<int>(name: nameof(Device.LocationId)),
               Name = table.Column<string>(name: nameof(Device.Name), maxLength: 30, defaultValue: string.Empty),
               DeviceType = table.Column<DeviceType>(name: nameof(Device.DeviceType)),
               PlcType = table.Column<PlcType>(name: nameof(Device.PlcType)),
               ModbusId = table.Column<byte>(name: nameof(Device.ModbusId), defaultValue: default(byte)),
               BoundRate = table.Column<SerialBoundRate>(name: nameof(Device.BoundRate)),
               DataBits = table.Column<SerialDataBits>(name: nameof(Device.DataBits)),
               Parity = table.Column<SerialParity>(name: nameof(Device.Parity)),
               StopBits = table.Column<SerialStopBits>(name: nameof(Device.StopBits)),
               SerialNumber = table.Column<string>(name: nameof(Device.SerialNumber), maxLength: 30, defaultValue: string.Empty),
               IncludeReport = table.Column<bool>(name: nameof(Device.IncludeReport), defaultValue: default(bool)),
               ReportSequence = table.Column<byte>(name: nameof(Device.ReportSequence), defaultValue: default(byte)),
               IsActive = table.Column<bool>(name: nameof(Device.IsActive), defaultValue: default(bool)),
               Version = table.Column<byte[]>(name: nameof(Device.Version), rowVersion: true),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(Device)}_{nameof(Device.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(Device)}_{nameof(Device.Location)}", x => x.LocationId, nameof(Location), principalColumn: nameof(Location.Id));
               table.UniqueConstraint($"UK_{nameof(Device)}_{nameof(Device.Location)}_{nameof(Device.Name)}", x => new { x.LocationId, x.Name });
               table.UniqueConstraint($"UK_{nameof(Device)}_{nameof(Device.Location)}_{nameof(Device.ModbusId)}", x => new { x.LocationId, x.ModbusId });
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(Device));
      }
   }
}
