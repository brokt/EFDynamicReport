﻿using System.Collections.Generic;
using System.Web.Http;
using SchoolReport.DB;
using SchoolReport.Models;

namespace SchoolReport.Controllers
{
    public class SchoolReportController : ApiController
    {
        private readonly SchoolDbContext _context;
        public SchoolReportController()
        {
            _context = new SchoolDbContext();
        }

        public SchoolReportController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("reports")]
        public IEnumerable<ReportTypeDTO> GetReportTypes()
        {
            return SchoolReportModel.GetReportTypes();
        }

        [HttpGet]
        [Route("reports/filters")]
        public IEnumerable<ReportFilterDTO> GetReportFilters()
        {
            return SchoolReportModel.GetReportFilterOperators();
        }

        [HttpGet]
        [Route("reports/{reportType}/columns")]
        public IEnumerable<ReportColumnDTO> GetReportColumns(int reportType)
        {
            return new SchoolReportModel((ReportType) reportType, _context).GetReportColumns();
        }

        [HttpPost]
        [Route("reports/{reportType}")]
        public List<Dictionary<string, object>> BuildNewReport(int reportType, ReportDTO report)
        {
            return new SchoolReportModel((ReportType)reportType, _context).GetReportData(report);
        }
    }
}