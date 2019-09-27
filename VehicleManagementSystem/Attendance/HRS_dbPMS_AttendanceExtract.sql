SELECT        TOP (200) EmpCode, FirstName, MidName, LastName, Initials, EmpName, TitleCode, EPFNo, ETFNo, NationalIDNo, GenderCode, DOB, CivilStatusCode, CAdd1, CAdd2, CAdd3, CDistrictCode, CCityCode, CTPNo, PAdd1, PAdd2, 
                         PAdd3, PTPNo, PDistrictCode, PCityCode, EMContactPerson, EMRelationCode, EMAdd1, EMAdd2, EMAdd3, EMTPNo, EDistrictCode, ECityCode, DateOfJoin, ProbationInDays, DateOfPermanent, EmpTypeCode, SalaryToBank, 
                         CardNo, PAYETax, OTAllow, KnownAs, CompCode, Inactive, InactiveBy, InactiveOn, PrviousEmpCode, SectionCode, DeptCode, LevelCategoryCode, TimeAttCardNo, ShiftCode, IsRostingShift, OCUCatCode, CategoryCode, EmilID, 
                         NothificationPhoneNo, NothificationEmail, DesignationCode, NationalityCode, CitizenCode, IsTaxPayByEmployer, EnterdBy, EnterdOn, IsPrintPayslip, IsPrintAchnowledgement, CompanyBranchCode, ActualDateOfPermanent, 
                         IsEpfEtf, IsFingerPrint, EMPID, Code, IsGratuity, LanguageCode, ReportTo, BasicSalaryPayTypeCode, IsProcessAttendance, IsPayTaxMonthly, IsPayTaxAnnual, IsPassport, IsPayTaxTable7, IsWHT, IsSync
FROM            Employee
ORDER BY EPFNo

----- Extract Employee details from HR system database
select   e.EmpName,  e.CTPNo ,  ( rtrim(e.CAdd1)+' '+rtrim(e.CAdd2)+' '+rtrim(e.CAdd3)),e.DOB, e.NationalIDNo,e.EPFNo,g.Gender,c.CivilStatus,'na@lbn.lk','N/A','N/A',1,0
from employee e, Gender g, CivilStatus c
where e.Inactive = 0 and e.DeptCode=  23 and e.GenderCode = g.GenderCode and e.CivilStatusCode =c.CivilStatusCode
order by e.EPFNo

---Attendance 
 --connect two databases    HRM (finger printer db) & dbPMS  // 

 select u.Badgenumber, c.CHECKTIME from HRM.dbo.CHECKINOUT c, HRM.dbo.USERINFO u ,dbPMS.dbo.Employee e
 where c.USERID = u.USERID and e.EPFNo = u.Badgenumber and
 c.CHECKTYPE = 'I' and  
 e.DeptCode=  23  and  
 e.Inactive = 0 and 
    c.CHECKTIME > '2018-10-23' 





	select * from View_Intime
