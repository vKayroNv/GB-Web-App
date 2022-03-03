using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Domain.Aggregates;
using Timesheets.Entities.Models;
using Timesheets.Interfaces.Managers;
using Timesheets.Interfaces.Repositories;

namespace Timesheets.Domain.Managers
{
    public class SheetManager : ISheetManager
    {
        private readonly ISheetRepository _repository;

        public SheetManager(ISheetRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(DateTime dateTime, CancellationToken cts)
        {
            var sheet = SheetAggregate.Create(dateTime);

            await _repository.Create(sheet, cts);

            return true;
        }

        public async Task<Sheet> Read(Guid id, CancellationToken cts)
        {
            return await _repository.Read(id, cts);
        }

        public async Task<IReadOnlyCollection<Sheet>> Read(CancellationToken cts)
        {
            return await _repository.Read(cts);
        }

        public async Task<bool> Approve(Guid sheetId, CancellationToken cts)
        {
            try
            {
                var sheet = SheetAggregate.ToAggregate(await Read(sheetId, cts));
                sheet.ApproveSheet();
                await _repository.Update(sheet, cts);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
