using Microsoft.EntityFrameworkCore.Migrations;
using Phoenix.Entities.Devices;
using Phoenix.Entities.Locations;
using Phoenix.Services.Extensions;
using Phoenix.Services.Repositories.Migrations.Base;
using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Services.Repositories.Migrations
{
   [Migration(nameof(Migration_202306251317_CreateDevices))]
   internal sealed class Migration_202306251317_CreateDevices : MigrationBase
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
               PlcType = table.Column<PlcType>(name: nameof(Device.PlcType)),
               ModbusId = table.Column<byte>(name: nameof(Device.ModbusId), defaultValue: default(byte)),
               BoundRate = table.Column<SerialBoundRate>(name: nameof(Device.BoundRate)),
               DataBits = table.Column<SerialDataBits>(name: nameof(Device.DataBits)),
               Parity = table.Column<SerialParity>(name: nameof(Device.Parity)),
               StopBits = table.Column<SerialStopBits>(name: nameof(Device.StopBits)),
               SerialNumber = table.Column<string>(name: nameof(Device.SerialNumber), maxLength: 30, defaultValue: string.Empty),
               Sequence = table.Column<byte>(name: nameof(Device.Sequence), defaultValue: default(byte)),
               IncludeReport = table.Column<bool>(name: nameof(Device.IncludeReport), defaultValue: default(bool)),
               IsActive = table.Column<bool>(name: nameof(Device.IsActive), defaultValue: default(bool)),
               Version = table.Column<short>(name: nameof(Device.Version), defaultValue: default(short)),
            },
            constraints: table =>
            {
               table.PrimaryKey($"PK_{nameof(Device)}_{nameof(Device.Id)}", x => x.Id);
               table.ForeignKey($"FK_{nameof(Device)}_{nameof(Device.Location)}", x => x.LocationId, principalTable: nameof(Location), principalColumn: nameof(Location.Id));
               table.UniqueConstraint($"UK_{nameof(Device)}_{nameof(Device.Location)}_{nameof(Device.Name)}", x => new { x.LocationId, x.Name });
               table.UniqueConstraint($"UK_{nameof(Device)}_{nameof(Device.Location)}_{nameof(Device.ModbusId)}", x => new { x.LocationId, x.ModbusId });
               table.UniqueConstraint($"UK_{nameof(Device)}_{nameof(Device.Location)}_{nameof(Device.Sequence)}", x => new { x.LocationId, x.Sequence });
            }
         );
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(nameof(Device));
      }
   }
}
