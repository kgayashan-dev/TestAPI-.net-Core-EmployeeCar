using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

public class DBAccess
{
 // private readonly string connetionString =
 //        @"Data Source=172.16.1.110;Initial Catalog=Destinity_Lease;User ID=sa;Password=2Forty2@44";
  private readonly string connetionString =
     @"Data Source=172.16.1.10;Initial Catalog=EmployeeCar;User ID=sa;Password=P@$$w0rd;TrustServerCertificate=True";
  
  // private readonly string connetionString =
  //     @"Data Source=172.16.1.10;Initial Catalog=Destinity_Lease;User ID=sa;Password=abcd@123;";

    //string connetionString = @"Data Source=172.16.1.210;Initial Catalog=Client;User ID=efin;Password=nations@2016";
    //string connetionString = @"Data Source=172.16.1.185;Initial Catalog=Client;User ID=sa;Password=abcd@123";
    //string connetionString = @"Data Source=172.16.1.186;Initial Catalog=Client;User ID=ey;Password=Test@123";

    public string PCSOFT_PopulateReceipt
    (
        object BranchID,
        object ReceiptDate,
        object CollectDate,
        object Amount,
        object Narration,
        object ReceiptDetail,
        object UserBranchID,
        object userID
    )
    {
        using (var con = new SqlConnection(connetionString))
        {
            con.Open();

            using (var cmd = new SqlCommand("[MicroFinance].[dbo].[Destinity_MF_Populate_Receipt]", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ReceiptType", "L");
                cmd.Parameters.AddWithValue("@BranchID", BranchID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GroupID", "0");
                cmd.Parameters.AddWithValue("@BPCode", DBNull.Value);
                cmd.Parameters.AddWithValue("@ReceiptDate", ReceiptDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CollectDate", CollectDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PaymentMethodID", "1");
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@ChequeBankBranch",DBNull.Value);
                cmd.Parameters.AddWithValue("@ChequeBankCode", DBNull.Value);
                cmd.Parameters.AddWithValue("@ChequeNo", DBNull.Value);
                cmd.Parameters.AddWithValue("@Narration", Narration ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ReceiptDetail", ReceiptDetail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UserBranchID", UserBranchID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UserID", userID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ChargeType", "RE");
                cmd.Parameters.AddWithValue("@GLAccountNo", "");
                cmd.Parameters.AddWithValue("@GLBranchCode", "");
                cmd.Parameters.AddWithValue("@PaymentPlaceID", "1");
                cmd.Parameters.AddWithValue("@PaymentReceivedTypeID", 1);
                cmd.Parameters.AddWithValue("@ReceiptFlow", "T");
                SqlParameter outputParameter = new SqlParameter("@ReceiptNoT", SqlDbType.VarChar, 500);
                outputParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);
                cmd.ExecuteNonQuery();
                return outputParameter.Value.ToString();
            }
        }
    }
    
    
    public void populateCEFTSOtherPayments(object ID,object CRAccount, object InfoID, object Amount, object PaymentMode,
        object isPaid, object CEFTSOtherPaymentsDetails, object userID, object IPAddress)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[populateCEFTSOtherPayments]", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@CRAccount", CRAccount ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@InfoID", InfoID ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Amount", Amount ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@isPaid", isPaid ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@CEFTSOtherPaymentsDetails", CEFTSOtherPaymentsDetails ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@IPAddress", IPAddress);

        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);
        cmd.ExecuteNonQuery();

        con.Close();
        //return dataTable;


        //con.Close();
        //return rowCount;
    }
    
    
    public void populateGLReceipt(object ID,object DRAccount, object ClientID, object Amount, object PaymentMode, object ChequeNo,
        object isCanceled,object ReceiptNarration, object GLReceiptDetails,object receiptBranch,object cashierBranch, object userID, object IPAddress)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[populateGLReceipt]", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@DRAccount", DRAccount ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ClientID", ClientID ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Amount", Amount ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ChequeNo", ChequeNo ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@isCanceled", isCanceled ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ReceiptNarration", ReceiptNarration ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@GLReceiptDetails", GLReceiptDetails ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@receiptBranch", receiptBranch ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@cashierBranch", cashierBranch ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@IPAddress", IPAddress);

        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);
        cmd.ExecuteNonQuery();

        con.Close();
        //return dataTable;


        //con.Close();
        //return rowCount;
    }
    
    public string PCSOFT_PopulateLoan(
        object GroupID, object LoanTypeID, object LoanDate, object InterestRate, object BusinessDetail,
        object LoanDetail, object GuarantorDetail, object IsUpdate, object UserID, object StageID = null,
        object StageLimitAndTotalCreditFac = null, object Stage = null, object LoanIndex = null,
        object RateOfInterest = null, object CompanyInfo = null, object UsingCompany = null,
        object BankDetail = null, object BusinessIncomeDetail = null, object BusinessExpenseDetail = null,
        object FamilyIncomeDetail = null, object FamilyExpenseDetail = null, object OtherPaymentDetail = null,
        object MainTotalDetail = null, object Relationship = null, object LoanAmount = null,
        object AmountWiseRateID = null, object PaymentMethodID = null, object DueStartDate = null, object IPAddress=null)
    {
        using (var con = new SqlConnection(connetionString))
        {
            con.Open();

            using (var cmd = new SqlCommand("[MicroFinance].[dbo].[Destinity_MF_Populate_Loan]", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@GroupID", GroupID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LoanTypeID", LoanTypeID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LoanDate", LoanDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@InterestRate", InterestRate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BusinessDetail", BusinessDetail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LoanDetail", LoanDetail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GuarantorDetail", GuarantorDetail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IsUpdate", IsUpdate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UserID", UserID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StageID", StageID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StageLimitAndTotalCreditFac",
                    StageLimitAndTotalCreditFac ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Stage", Stage ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LoanIndex", LoanIndex ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RateOfInterest", RateOfInterest ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CompanyInfo", CompanyInfo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UsingCompany", UsingCompany ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BankDetail", BankDetail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BusinessIcomeDetail", BusinessIncomeDetail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BusinessExpenseDetail", BusinessExpenseDetail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FamilyIncomeDetail", FamilyIncomeDetail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FamilyExpenseDetail", FamilyExpenseDetail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OtherPaymentDetail", OtherPaymentDetail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MainTotalDetail", MainTotalDetail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Relationship", Relationship ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LoanAmount", LoanAmount ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AmountWiseRateID", AmountWiseRateID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DueStartDate", DueStartDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPAddress", IPAddress ?? DBNull.Value);
                SqlParameter outputParameter = new SqlParameter("@LoanNo", SqlDbType.VarChar, 100);
                outputParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);
                cmd.ExecuteNonQuery();
                return outputParameter.Value.ToString();
            }
        }
    }

    public void PCSOFT_MF_Populate_Member(
        object GroupID, object BPCode, object AppDate, object IsGroupLeader, object Relationship,
        object AccountDetail, object MemberOtherIncome, object MemberAssLib, object SectorCode,
        object TotalIncome, object IncomePeriodID, object TotalExpenditure, object SavingsAmount,
        object ExpenditurePeriodID, object MemberID, object UpdateMode, object AccountNo,
        object UserID, out string MemberCode, object MemCode = null, object MemberNo = null,
        object MemberNoDetails = null, object ReligionID = null, object EducationalLevelID = null,
        object LocationID = null, object IsHandicapped = null, object FamilyDetails = null,
        object FamilyOtherDetails = null, object HouseholdInfo = null, object FinancialAccessDetails = null,
        object FinancialAccessOtherDetails = null, object PPIIndicators = null,
        object FinancialAccessSavingsTypes = null, object IPAddress = null)
    {
        //MemberCode = string.Empty;

        using (var con = new SqlConnection(connetionString))
        {
            con.Open();

            using (var cmd = new SqlCommand("[MicroFinance].[dbo].[Destinity_MF_Populate_Member]", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Adding parameters for the stored procedure
                cmd.Parameters.AddWithValue("@GroupID", GroupID);
                cmd.Parameters.AddWithValue("@BPCode", BPCode);
                cmd.Parameters.AddWithValue("@AppDate", AppDate);
                cmd.Parameters.AddWithValue("@IsGroupLeader", IsGroupLeader);
                cmd.Parameters.AddWithValue("@Relationship", Relationship);
                cmd.Parameters.AddWithValue("@AccountDetail", AccountDetail);
                cmd.Parameters.AddWithValue("@MemberOtherInome", MemberOtherIncome);
                cmd.Parameters.AddWithValue("@MemberAssLib", MemberAssLib);
                cmd.Parameters.AddWithValue("@SectorCode", SectorCode);
                cmd.Parameters.AddWithValue("@TotalIncome", TotalIncome);
                cmd.Parameters.AddWithValue("@IncomePeriodID", IncomePeriodID);
                cmd.Parameters.AddWithValue("@TotalExpenditure", TotalExpenditure);
                cmd.Parameters.AddWithValue("@SavingsAmount", SavingsAmount);
                cmd.Parameters.AddWithValue("@ExpenditurePeriodID", ExpenditurePeriodID);
                cmd.Parameters.AddWithValue("@MemberID", MemberID);
                cmd.Parameters.AddWithValue("@UpdateMode", UpdateMode);
                cmd.Parameters.AddWithValue("@AccountNo", AccountNo);
                cmd.Parameters.AddWithValue("@UserID", UserID);

                // Output parameter
                var memberCodeParam = new SqlParameter("@MemberCode", SqlDbType.VarChar, 30)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(memberCodeParam);

                // Optional parameters with default values
                cmd.Parameters.AddWithValue("@MemCode", MemCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MemberNo", MemberNo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MemberNoDetails", MemberNoDetails ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ReligionID", ReligionID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EducationalLevelID", EducationalLevelID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LocationID", LocationID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IsHandicapped", IsHandicapped ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FamilyDetails", FamilyDetails ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FamilyOtherDetails", FamilyOtherDetails ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HouseholdInfo", HouseholdInfo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FinancialAccessDetails", FinancialAccessDetails ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FinancialAccessOtherDetails",
                    FinancialAccessOtherDetails ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PPIIndicators", PPIIndicators ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FinancialAccessSavingsTypes",
                    FinancialAccessSavingsTypes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IPAddress", IPAddress ?? DBNull.Value);
                // Execute the stored procedure
                cmd.ExecuteNonQuery();

                // Retrieve the output parameter value
                MemberCode = memberCodeParam.Value.ToString();
            }
        }
    }

    public DataTable PCSOFT_getMFMemberCode(object GroupID, object CenterID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[Destinity_MF_GenerateMemberCode]", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@GroupID", GroupID);
        cmd.Parameters.AddWithValue("@CenterID", CenterID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable PCSOFT_getMFGroupList(object CenterID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[PCSOFT_Get_Group]", con);

        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CenterID", CenterID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public void PCSOFT_MF_Populate_group(object CenterID, object GroupID, object Code, object Description,
        object CollectionDayID, object FieldOfficerID, object UpdateMode, object UserID, object companyInfo,
        object txtTotalCreditFacility, object txtStageLimit, object CreditFacilityAndStageLimit, object Stages,
        object Stage, object IPAddress)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[Destinity_MF_Populate_Group]", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CenterID", CenterID);
        cmd.Parameters.AddWithValue("@GroupID", GroupID);
        cmd.Parameters.AddWithValue("@Code", Code);
        cmd.Parameters.AddWithValue("@Description", Description);
        cmd.Parameters.AddWithValue("@CollectionDayID", CollectionDayID);
        cmd.Parameters.AddWithValue("@FieldOfficerID", FieldOfficerID);
        cmd.Parameters.AddWithValue("@UpdateMode", UpdateMode);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@companyInfo", companyInfo);
        cmd.Parameters.AddWithValue("@txtTotalCreditFacility", txtTotalCreditFacility);
        cmd.Parameters.AddWithValue("@txtStageLimit", txtStageLimit);
        cmd.Parameters.AddWithValue("@CreditFacilityAndStageLimit", CreditFacilityAndStageLimit);
        cmd.Parameters.AddWithValue("@Stages", Stages);
        cmd.Parameters.AddWithValue("@Stage", Stage);
        cmd.Parameters.AddWithValue("@IPAddress", IPAddress);

        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);
        cmd.ExecuteNonQuery();

        con.Close();
        //return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable PCSOFT_getMFCenterList(string BranchID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[PCSOFT_Get_Centers]", con);
        cmd.Parameters.AddWithValue("@BranchID", BranchID);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@CID", CID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable PCSOFT_getMFBranchList()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[PCSOFT_getMFBranchList]", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@CID", CID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable Destinity_MF_Select_PaymentMethod()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[Destinity_MF_Select_PaymentMethod]", con);

        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@CID", CID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public void PCSOFT_MF_Populate_Center(string CenterID, string BranchID, string Code, string Description,
        string UpdateMode, string UserID, string CollectionDayID, string FieldOfficerID, string companyInfo,
        string CenterLeader, string IPAddress)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[Destinity_MF_Populate_Center]", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CenterID", CenterID);
        cmd.Parameters.AddWithValue("@BranchID", BranchID);
        cmd.Parameters.AddWithValue("@Code", Code);
        cmd.Parameters.AddWithValue("@Description", Description);
        cmd.Parameters.AddWithValue("@UpdateMode", UpdateMode);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@CollectionDayID", CollectionDayID);
        cmd.Parameters.AddWithValue("@FieldOfficerID", FieldOfficerID);
        cmd.Parameters.AddWithValue("@companyInfo", companyInfo);
        cmd.Parameters.AddWithValue("@CenterLeader", CenterLeader);
        cmd.Parameters.AddWithValue("@IPAddress", IPAddress);


        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);
        cmd.ExecuteNonQuery();

        con.Close();
        //return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable PC_Soft_Get_Fieldofficer()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[PCSOFT_Get_Fieldofficer]", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@CID", CID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable PCSOFT_GetAspnetUsers()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[Destinity_Lease].[dbo].PCSOFT_GetAspnetUsers", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@CID", CID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable PC_Soft_Get_branches()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].PCSOFT_Get_branches", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@CID", CID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public void PCSOFT_PopolateCollectionOfficer(string FieldOfficerID, string BPCode, string EPFNo, string FirstName,
        string LastName, string NICNo, string TelephoneNo, string MobileNo, string Category,
        string UpdateMode, string UserID, string BranchID, string UserLoginID, string IPAddress)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].Destinity_MF_Populate_FieldOfficer", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FieldOfficerID", FieldOfficerID);
        cmd.Parameters.AddWithValue("@BPCode", BPCode);
        cmd.Parameters.AddWithValue("@EPFNo", EPFNo);
        cmd.Parameters.AddWithValue("@FirstName", FirstName);
        cmd.Parameters.AddWithValue("@LastName", LastName);
        cmd.Parameters.AddWithValue("@NICNo", NICNo);
        cmd.Parameters.AddWithValue("@TelephoneNo", TelephoneNo);
        cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
        cmd.Parameters.AddWithValue("@Category", Category);
        cmd.Parameters.AddWithValue("@UpdateMode", UpdateMode);
        cmd.Parameters.AddWithValue("@BranchID", BranchID);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@UserLoginID", UserLoginID);
        cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
        //int rowCount = cmd.ExecuteNonQuery();

        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);
        cmd.ExecuteNonQuery();

        con.Close();
        //return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable Client_getApprovalDetails()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[Destinity_Lease].[dbo].Client_getApprovalDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@isFullProfile", isFullProfile);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GetClientDetails(string searchValue, int isFullProfile, string SeqNo)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[Destinity_Lease].[dbo].Client_getDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@isFullProfile", isFullProfile);
        cmd.Parameters.AddWithValue("@searchValue", searchValue);
        cmd.Parameters.AddWithValue("@SeqNo", SeqNo);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }
    
    public DataTable GetClientDetails(string searchValue)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[getMemberDetails]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@searchValue", searchValue);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Client_getDistrict() // added by hansani
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[Destinity_Lease].[dbo].Client_getDistrict", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@CID", CID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable ClientgetTitle()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[Destinity_Lease].[dbo].Client_getTile", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@CID", CID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable ClientgetSectorDetails()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[Destinity_Lease].[dbo].getSectorDetails", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@CID", CID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable Client_getOccupation()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[Destinity_Lease].[dbo].Client_getOccupation", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@CID", CID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable ClientInsertOrUpdateClientProfile(object CID, string SeqNo, string DOB, string Occupation,
        string IPAddress, string Title, string CType, string Gender, string userid,
        string OLDNICNo, string NEWNICNo, string PassportNumber, string BRNo,
        string DLNo, string Email, string Addr1, string Addr2, string Addr3, string Addr4,
        string DistrictCode, string FirstName, string LastName, string NameWIthInitials, string FullName,
        string TelOffice, string TellResidence, string Mobile, string Fax, string SectorCode,
        string Status, string MaritalStatus, string AliasName, string IsVATRegistered, string TINNo,object bankBranchID, object bankAccountNo)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[Destinity_Lease].[dbo].InsertOrUpdateClientProfile", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CID", CID ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@SeqNo", SeqNo);
        cmd.Parameters.AddWithValue("@DOB", DOB);
        cmd.Parameters.AddWithValue("@Occupation", Occupation);
        cmd.Parameters.AddWithValue("@Title", Title);
        cmd.Parameters.AddWithValue("@CType", CType);
        cmd.Parameters.AddWithValue("@Gender", Gender);
        cmd.Parameters.AddWithValue("@OLDNICNo", OLDNICNo);
        cmd.Parameters.AddWithValue("@NEWNICNo", NEWNICNo);
        cmd.Parameters.AddWithValue("@PassportNumber", PassportNumber);
        cmd.Parameters.AddWithValue("@BRNo", BRNo);
        cmd.Parameters.AddWithValue("@DLNo", DLNo);
        cmd.Parameters.AddWithValue("@Email", Email);
        cmd.Parameters.AddWithValue("@Addr1", Addr1);
        cmd.Parameters.AddWithValue("@Addr2", Addr2);
        cmd.Parameters.AddWithValue("@Addr3", Addr3);
        cmd.Parameters.AddWithValue("@Addr4", Addr4);
        cmd.Parameters.AddWithValue("@DistrictCode", DistrictCode);
        cmd.Parameters.AddWithValue("@userid", userid);
        cmd.Parameters.AddWithValue("@FirstName", FirstName);
        cmd.Parameters.AddWithValue("@LastName", LastName);
        cmd.Parameters.AddWithValue("@NameWIthInitials", NameWIthInitials);
        cmd.Parameters.AddWithValue("@FullName", FullName);
        cmd.Parameters.AddWithValue("@TelOffice", TelOffice);
        cmd.Parameters.AddWithValue("@TellResidence", TellResidence);
        cmd.Parameters.AddWithValue("@Mobile", Mobile);
        cmd.Parameters.AddWithValue("@Fax", Fax);
        cmd.Parameters.AddWithValue("@SectorCode", SectorCode);
        cmd.Parameters.AddWithValue("@Status", Status);
        cmd.Parameters.AddWithValue("@MaritalStatus", MaritalStatus);
        cmd.Parameters.AddWithValue("@AliasName", AliasName);
        cmd.Parameters.AddWithValue("@IsVATRegistered", IsVATRegistered);
        cmd.Parameters.AddWithValue("@TINNo", TINNo);
        cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
        cmd.Parameters.AddWithValue("@bankBranchID", bankBranchID ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@bankAccountNo", bankAccountNo ?? DBNull.Value);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable getData(string query)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        var table = new DataTable();
        cmd = new SqlCommand(query, con);
        cmd.CommandTimeout = 1000;

        var adpt = new SqlDataAdapter(cmd);
        adpt.Fill(table);

        con.Close();
        return table;
    }
    
    public DataSet getDataSet(string query)
    {
        SqlConnection con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.CommandTimeout = 1000;

        DataSet dataSet = new DataSet();
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        adpt.Fill(dataSet); // This fills multiple tables in the DataSet
        con.Close();

        return dataSet; // Return the DataSet containing both tables
    }

    public DataTable getData(string storedProcName, SqlParameter[] parameters = null)
    {
        try
        {
            using (var con = new SqlConnection(connetionString))
            {
                using (var cmd = new SqlCommand(storedProcName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 60; // Set a reasonable timeout

                    // Add parameters if provided
                    if (parameters != null) cmd.Parameters.AddRange(parameters);

                    var adapter = new SqlDataAdapter(cmd);
                    var resultTable = new DataTable();

                    // Open connection, fill data, and return result
                    con.Open();
                    adapter.Fill(resultTable);

                    return resultTable;
                }
            }
        }
        catch (Exception ex)
        {
            // Log or rethrow the exception as needed
            throw new ApplicationException($"Error executing stored procedure '{storedProcName}'", ex);
        }
    }

    public int insertData(string query)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand(query, con);
        var rowCount = cmd.ExecuteNonQuery();

        con.Close();
        return rowCount;
    }

    public int SP_CEFTS_Confirm(string bspCode, string BspUserID, int ApproveID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].CEFTS_Confirm", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@bspCode", bspCode);
        cmd.Parameters.AddWithValue("@bspUserid", BspUserID);
        cmd.Parameters.AddWithValue("@ApproveID", ApproveID);
        var rowCount = cmd.ExecuteNonQuery();

        con.Close();
        return rowCount;
    }

    public int HIRS_Emp_Availability(string ServiceNo, string userID, string IPAddress)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].HIRS_Emp_Availability", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ServiceNo", ServiceNo);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
        var rowCount = cmd.ExecuteNonQuery();

        con.Close();
        return rowCount;
    }

    public int HRIS_Save_EMP_Resignation(string isInsert, string epfNo, string resignedDate, string isupdated,
        string userid, string IPAddress)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].HRIS_Save_EMP_Resignation", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@isInsert", isInsert);
        cmd.Parameters.AddWithValue("@epfNo", epfNo);
        cmd.Parameters.AddWithValue("@resignedDate", resignedDate);
        cmd.Parameters.AddWithValue("@isupdated", isupdated);
        cmd.Parameters.AddWithValue("@userid", userid);
        cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
        var rowCount = cmd.ExecuteNonQuery();

        con.Close();
        return rowCount;
    }

    public DataTable GetPWPortFolioDetails(string asAtDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].PW_PortFolio_Details", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@AsAtDate", asAtDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GET_INV_Device_List(string searchValue1, string searchValue2, string searchValue3, string Sno,
        string epfNo, string branch)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].GET_INV_Device_List", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@searchValue1", searchValue1);
        cmd.Parameters.AddWithValue("@searchValue2", searchValue2);
        cmd.Parameters.AddWithValue("@searchValue3", searchValue3);
        cmd.Parameters.AddWithValue("@Sno", Sno);
        cmd.Parameters.AddWithValue("@epfNo", epfNo);
        cmd.Parameters.AddWithValue("@branch", branch);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable INV_Get_Invoice_Details(string ID, string SearchValue)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].INV_Get_Invoice_Details", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@SearchValue", SearchValue);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GET_FD_Transaction_Listing_Long(string fromDate, string toDate, string mode)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].GET_FD_Transaction_Listing_Long", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        cmd.Parameters.AddWithValue("@mode", mode);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable FD_Maturity_Validation_For_Loan(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].FD_Maturity_Validation_For_Loan", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable getSavingsBaseWithLoanNo(string asAtDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].SavingsBase", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@asAtDate", asAtDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable deposit_base_long(string asAtDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].deposit_base_long", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@TxnDate", asAtDate);
        cmd.Parameters.AddWithValue("@BranchCode", "ALL");
        cmd.Parameters.AddWithValue("@PayMode", "ALL");
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable getCEFTS_FDPayeeDetails(string fdNo)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].getCEFTS_FDPayeeDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fdNo", fdNo);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable getCEFTS_BSPDetails(string bpCode)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].getCEFTS_BSPDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@bpCode", bpCode);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GetCMPortFolio()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].CM_Collections", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@AsAtDate", asAtDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GetLEArrearsReport()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[LE_Arrears_Report]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@AsAtDate", asAtDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GetLEArrearsReportSummary()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[LE_Arrears_Report_Summary]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@AsAtDate", asAtDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GetFDBaseReport(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[FD_Interest_Payment]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GetHRISReports(string fromDate, string toDate, string reportType)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[HIRS_Reports]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        cmd.Parameters.AddWithValue("@reportType", reportType);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Acc_Transaction_Details(string txnNo)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Acc_Transaction_Details]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@txnNo", txnNo);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GetHRISEmployeeLeaveBalance(string epfNo, string year)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[HRIS_EMP_Leave_Balance]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@epfNo", epfNo);
        cmd.Parameters.AddWithValue("@year", year);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable EMP_Details(string epfNo)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[EMP_Details]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@epfNo", epfNo);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable getBranchMapping(string branchName, string divisionName)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[getBranchMapping]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@branchName", branchName);
        cmd.Parameters.AddWithValue("@divisionName", divisionName);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable LE_Receipt_Details(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[LE_Receipt_Details]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable PW_ReceiptDetail(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[PW_ReceiptDetail]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@BranchCode", "ALL");
        cmd.Parameters.AddWithValue("@SDate", fromDate);
        cmd.Parameters.AddWithValue("@EDate", toDate);
        //cmd.Parameters.AddWithValue("@UserID", "NULL");
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GET_FD_Report_PaymentSchedule(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[GET_FD_Report_PaymentSchedule]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@BranchCode", "ALL");
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        //cmd.Parameters.AddWithValue("@UserID", "NULL");
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GET_FD_ReceiptEntries(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[GET_FD_ReceiptEntries]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@BranchCode", "ALL");
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        //cmd.Parameters.AddWithValue("@UserID", "NULL");
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GET_FD_Interest_Pay_Due(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[GET_FD_Interest_Pay_Due]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@BranchCode", "ALL");
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        //cmd.Parameters.AddWithValue("@UserID", "NULL");
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GET_FD_WHTSchedule(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[GET_FD_WHTSchedule]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@BranchCode", "ALL");
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        //cmd.Parameters.AddWithValue("@UserID", "NULL");
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GET_FD_Report_LoanDetails(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[GET_FD_Report_LoanDetails]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@BranchCode", "ALL");
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        //cmd.Parameters.AddWithValue("@UserID", "NULL");
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_LE_Insurance_Renewal_List(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_LE_Insurance_Renewal_List]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@BranchCode", "ALL");
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        //cmd.Parameters.AddWithValue("@UserID", "NULL");
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GET_CEFTS_EMP_Fuel_Details(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[GET_CEFTS_EMP_Fuel_Details]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@BranchCode", "ALL");
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        //cmd.Parameters.AddWithValue("@UserID", "NULL");
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable MF_ReceiptDetail(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[MF_Report_ReceiptDetails]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@BranchCode", "ALL");
        cmd.Parameters.AddWithValue("@FromDate", fromDate);
        cmd.Parameters.AddWithValue("@ToDate", toDate);
        //cmd.Parameters.AddWithValue("@UserID", "NULL");
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable LE_Rental_Due(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[LE_Rental_Due]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable LE_MIS_Daily_Collection(int reportType)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[LE_MIS_Daily_Collection]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@reportType", reportType);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable update_MF_Member_SavingsAC(string BSPCode, string AccountNo, string userID, string IPAddress)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[update_MF_Member_SavingsAC]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@BSPCode", BSPCode);
        cmd.Parameters.AddWithValue("@SavingAccountNo", AccountNo);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable getCEFTS_ClientDetailsForApproval(string branchName, int isConfirmedID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[getCEFTS_ClientDetailsForApproval]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();
        cmd.Parameters.AddWithValue("@branchName", branchName);
        cmd.Parameters.AddWithValue("@isConfirmedID", isConfirmedID);
        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable getCEFTS_Customer_Account_Details_Status(string branchName, int isConfirmedID, string fromDate,
        string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[getCEFTS_Customer_Account_Details_Status]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();
        cmd.Parameters.AddWithValue("@branchName", branchName);
        cmd.Parameters.AddWithValue("@isConfirmedID", isConfirmedID);
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GetGL_OutsidePartyPayments(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[GL_OutsidePartyPayments]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GetLECollectionReport()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[LE_Collection_Report]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@AsAtDate", asAtDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_Other_ReimbursementData(string userID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Other_getReimbursementData]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@userID", userID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_INV_Make_Data()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_INV_Make_Data]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@userID", userID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_INV_Payment_Types()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_INV_Payment_Types]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@userID", userID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_INV_Vendors()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_INV_Vendors]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@userID", userID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable INV_Get_IT_Users()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[INV_Get_IT_Users]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@userID", userID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_Inv_Processor_Data()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_INV_Processor_Data]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@userID", userID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_Inv_RAM_Data()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_INV_RAM_Data]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@userID", userID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_Inv_OS_Data()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_INV_OS_Data]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@userID", userID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_Inv_Bit_Data()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_INV_OS_BIT_VERSION_Data]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@userID", userID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_Inv_Purchase_Status_Data()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_INV_Purchase_status_Data]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@userID", userID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_INV_Model_Data(string MakeID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_INV_Model_Data]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@MakeID", MakeID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_INV_Payment_Sub_Types(string TypeID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_INV_Payment_Sub_Types]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@TypeID", TypeID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_Other_ReimbursementDetails()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Other_getReimbursementDetails]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        //cmd.Parameters.AddWithValue("@userID", userID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable CEFTS_getEmpFuelToBePaid(string asAtDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_getEmpFuelToBePaid]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@asAtDate", asAtDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable CEFTS_getEmpFuelToBePaidSortByDate(string asAtDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_getEmpFuelToBePaidSortByDate]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@asAtDate", asAtDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable CEFTS_Generate_GL_File(string batchID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_Generate_GL_File]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@batchID", batchID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable CEFTS_Get_GL_CR_Value(string batchID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_Get_GL_CR_Value]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@batchID", batchID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable CEFTS_get_FuelBatchIDs_FromCEFTSID(string ceftsID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_get_FuelBatchIDs_FromCEFTSID]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@ceftsID", ceftsID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    //GET_FD_Interest_Cost
    public DataTable GET_FD_Interest_Cost(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[GET_FD_Interest_Cost]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable pw_int_income(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[pw_int_income]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable SA_Interest_Cost(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[SA_Interest_Cost]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_MF_Arrears(string asAtDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_MF_Arrears]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@asAtDate", asAtDate);
        //cmd.Parameters.AddWithValue("@toDate", toDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public int CEFTS_GenerateEmpFuelDetails(DataTable empPaymentIDs, string userID, string batchID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_GenerateEmpFuelDetails]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@empPaymentIDs", empPaymentIDs);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@batchID", batchID);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public string[] INV_Save_Invoice
    (
        long ID,
        string SubPayment_Type_ID,
        string InvoiceNo,
        string Invoice_Date,
        string Invoice_amount,
        string Payment_AMC_ID,
        string Vendor,
        string GRN_No,
        string StartDate,
        string EndDate,
        string docBit,
        string Discription,
        string Cost,
        string PreparedBy,
        string ApprovedBy,
        string ChequeDate,
        string ChequeAcceptBy,
        DataTable deviceList,
        string userID,
        string IPAddress
    )
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[INV_Save_Invoice]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@SubPayment_Type_ID", SubPayment_Type_ID);
        cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
        cmd.Parameters.AddWithValue("@Invoice_Date", Invoice_Date);
        cmd.Parameters.AddWithValue("@Invoice_amount", Invoice_amount);
        cmd.Parameters.AddWithValue("@Payment_AMC_ID", Payment_AMC_ID);
        cmd.Parameters.AddWithValue("@Vendor", Vendor);
        cmd.Parameters.AddWithValue("@GRN_No", GRN_No);
        cmd.Parameters.AddWithValue("@StartDate", StartDate);
        cmd.Parameters.AddWithValue("@EndDate", EndDate);
        //cmd.Parameters.AddWithValue("@Company", Company);
        cmd.Parameters.AddWithValue("@docBit", docBit);
        cmd.Parameters.AddWithValue("@Discription", Discription);
        cmd.Parameters.AddWithValue("@Cost", Cost);
        cmd.Parameters.AddWithValue("@PreparedBy", PreparedBy);
        cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy);
        cmd.Parameters.AddWithValue("@ChequeDate", ChequeDate);
        cmd.Parameters.AddWithValue("@ChequeAcceptBy", ChequeAcceptBy);
        cmd.Parameters.AddWithValue("@InvDeviceList", deviceList);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@IPAddress", IPAddress);


        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;

        //s
        var DocFilename = new SqlParameter();
        DocFilename.ParameterName = "@DocFilename";
        DocFilename.SqlDbType = SqlDbType.VarChar;
        DocFilename.Size = 100;
        DocFilename.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(DocFilename);

        var InsertedID = new SqlParameter();
        InsertedID.ParameterName = "@InsertedID";
        InsertedID.SqlDbType = SqlDbType.VarChar;
        InsertedID.Size = 100;
        InsertedID.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(InsertedID);

        cmd.ExecuteNonQuery();
        var fileName = cmd.Parameters["@DocFilename"].Value.ToString();
        var DocID = cmd.Parameters["@InsertedID"].Value.ToString();

        //e

        var returnValue = Convert.ToInt32(returnValueParam.Value);

        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        var values = new string[2];
        values[0] = fileName;
        values[1] = DocID;
        return values;
    }

    public string Save_INV_Device_location(string ID, string LCode, string DeviceID, int isActive, string OwnedbyuserID,
        string userID, int isInsert, bool hasFile)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Save_INV_Device_location]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@LCode", LCode);
        cmd.Parameters.AddWithValue("@DeviceID", DeviceID);
        cmd.Parameters.AddWithValue("@isActive", isActive);
        cmd.Parameters.AddWithValue("@OwnedbyuserID", OwnedbyuserID);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@isInsert", isInsert);

        var outputParameter = new SqlParameter();
        outputParameter.ParameterName = "@nextID";
        outputParameter.SqlDbType = SqlDbType.BigInt;
        outputParameter.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(outputParameter);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var nextID = (long)cmd.Parameters["@nextID"].Value;

        var returnValue = Convert.ToInt32(returnValueParam.Value);

        if (returnValue == 1 && hasFile)
        {
            cmd = new SqlCommand("[MIS].[dbo].[INV_SAVE_Device_location_doc]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 1000;
            cmd.Parameters.AddWithValue("@Device_location_ID", nextID);
            //cmd.Parameters.AddWithValue("@DocFilename", LCode.ToString()+".pdf");
            cmd.Parameters.AddWithValue("@userID", userID);
            returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
            returnValueParam.Direction = ParameterDirection.ReturnValue;

            outputParameter = new SqlParameter();
            outputParameter.ParameterName = "@DocFilename";
            outputParameter.SqlDbType = SqlDbType.VarChar;
            outputParameter.Size = 100;
            outputParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParameter);

            cmd.ExecuteNonQuery();
            var fileName = cmd.Parameters["@DocFilename"].Value.ToString();
            returnValue = Convert.ToInt32(returnValueParam.Value);

            if (returnValue == 1) return fileName;
        }

        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue.ToString();
    }

    public int CEFTS_Task_lock(int id)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_Task_lock]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@ID", id);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int CEFTS_Task_Release(int id)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_Task_Release]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@ID", id);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int INV_MakeSave(string ID, string Description)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[INV_MakeSave]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@Description", Description);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;

        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);

        con.Close();
        return returnValue;
    }

    public int INV_DeviceSave(string ID, string SerialNo,
        string Model,
        string Gen,
        string Processor,
        string RAM,
        string OS_Bit,
        string IP,
        string Purchase_Date,
        string Warranty_ExpDate,
        string Purchase_Status,
        string OS,
        string InvoiceNo,
        string DeviceType,
        string MonitorSer
    )
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[INV_DeviceSave]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@SerialNo", SerialNo);
        cmd.Parameters.AddWithValue("@Model", Model);
        cmd.Parameters.AddWithValue("@Gen", Gen);
        cmd.Parameters.AddWithValue("@Processor", Processor);
        cmd.Parameters.AddWithValue("@RAM", RAM);
        cmd.Parameters.AddWithValue("@OS_Bit", OS_Bit);
        cmd.Parameters.AddWithValue("@IP", IP);
        cmd.Parameters.AddWithValue("@Purchase_Date", Purchase_Date);
        cmd.Parameters.AddWithValue("@Warranty_ExpDate", Warranty_ExpDate);
        cmd.Parameters.AddWithValue("@Purchase_Status", Purchase_Status);
        cmd.Parameters.AddWithValue("@OS", OS);
        cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
        cmd.Parameters.AddWithValue("@DeviceType", DeviceType);
        cmd.Parameters.AddWithValue("@monitorSer", MonitorSer);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;

        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);

        con.Close();
        return returnValue;
    }

    public int INV_ModelSave(string ID, string MakeID, string Description)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[INV_ModelSave]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@MakeID", MakeID);
        cmd.Parameters.AddWithValue("@Description", Description);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;

        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);

        con.Close();
        return returnValue;
    }
    
    public void CEFTS_GenerateOtherPaymentDetails(DataTable PaymentVoucherNos,string AccCode, string userID, string batchID)
    {
        
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_GenerateOtherPaymentDetails]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@PaymentInvoiceNos", PaymentVoucherNos);
        cmd.Parameters.AddWithValue("@AccCode", AccCode);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@batchID", batchID);

        // var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        // returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        //var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        //return returnValue;
    }
    public int CEFTS_GenerateMFDetails(DataTable PaymentVoucherNos,string CRAccCode,string DRAccCode, string userID, string batchID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_GenerateMFDetails]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@PaymentVoucherNos", PaymentVoucherNos);
        cmd.Parameters.AddWithValue("@CRAccCode", CRAccCode);
        cmd.Parameters.AddWithValue("@DRAccCode", DRAccCode);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@batchID", batchID);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int CEFTS_GenerateSavingsDetails(DataTable PaymentVoucherNos, string userID, string batchID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_GenerateSavingsDetails]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@PaymentVoucherNos", PaymentVoucherNos);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@batchID", batchID);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int CEFTS_GenerateFDDetails(DataTable PaymentVoucherNos, string userID, string batchID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_GenerateFDDetails]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@PaymentVoucherNos", PaymentVoucherNos);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@batchID", batchID);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }
    
    
    public void populate_GL_Other_Payment(object InvoiceNos,object AccCode,object chequeNo, object isCanceled, object userID,object IPAddress)
    {
        
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[populate_GL_Other_Payment]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@ID", DBNull.Value);
        cmd.Parameters.AddWithValue("@invoiceNos", InvoiceNos);
        cmd.Parameters.AddWithValue("@AccCode", AccCode);
        cmd.Parameters.AddWithValue("@chequeNo", chequeNo);
        cmd.Parameters.AddWithValue("@isCanceled", isCanceled ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@IPAddress", IPAddress);

        // var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        // returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        //var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        //return returnValue;
    }

    public int cancelCEFTSPayment(DataTable empPaymentIDs)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[cancelCEFTSPayment]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@empPaymentIDs", empPaymentIDs);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int HRISupdateReportingPerson(string empEpfNo, string reportingEpfNo)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[HRIS_updateReportingPerson]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@empEpfNo", empEpfNo);
        cmd.Parameters.AddWithValue("@rptEptNo", reportingEpfNo);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int SaveEmpBranchMapping(DataTable empBranchMap, string epfno)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[SaveEmpBranchMapping]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@empBranchMap", empBranchMap);
        cmd.Parameters.AddWithValue("@epfno", epfno);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public DataTable CETFS_Get_Savings_Details()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CETFS_Get_Savings_Details]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }


    public DataTable CETFS_Get_FD_Details()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CETFS_Get_FD_Details]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_CEFTS_Customer_Payment_Details(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_CEFTS_Customer_Payment_Details]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable get_Invoce_Details(string ID, string Invoice_AMC_type)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[get_Invoce_Details]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@Invoice_AMC_type", Invoice_AMC_type);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable get_INV_DocInfo(string DeviceID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[get_INV_DocInfo]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@deviceiD", DeviceID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable get_INV_Invoice_DocInfo(string DeviceID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[get_INV_Invoice_DocInfo]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@deviceiD", DeviceID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GET_HRIS_Leave_History(string epfNo, string year)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[HRIS_Leave_History]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@epfNo", epfNo);
        cmd.Parameters.AddWithValue("@year", year);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable CEFTS_getBSPAccDetails(string bspCode)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_getBSPAccDetails]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@bspCode", bspCode);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Get_CEFTS_Customer_Printed_Details(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Get_CEFTS_Customer_Printed_Details]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable GL_CashTransferFromHeadOffice(string fromDate, string toDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[GL_CashTransferFromHeadOffice]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@toDate", toDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable LE_Arrears_Report_AS_AT_DATE(string asAtDate)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[LE_Arrears_Report_AS_AT_DATE]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@asAtDate", asAtDate);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable getCEFTSGenerationDetails(DataTable batchIDs)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[getCEFTSGenerationDetails]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@batchIDs", batchIDs);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable getCEFTSGenerationDetailsByBatch_CEFTSID(string batchID_CeftsID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[getCEFTSGenerationDetailsByBatch_CEFTSID]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@batch_CeftsID", batchID_CeftsID);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable SavingsAndCreditNoteWithdrawal(string fromDate, string toDate, string branchCode)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[SavingsAndCreditNoteWithdrawal]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        cmd.Parameters.AddWithValue("@todate", toDate);
        cmd.Parameters.AddWithValue("@branchCode", branchCode);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable getBranchList()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[getBranchList]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable getBatchDetailsTobeGenerated()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[getBatchDetailsTobeGenerated]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }


    public string getNextCEFTSID()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[getNextCEFTSID]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable.Rows[0][0].ToString();
    }

    public string getNextBatchID()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[getNextBatchID]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable.Rows[0][0].ToString();
    }


    public int HoldReleaseFuel(string empEpfNo)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[HoldReleaseFuel]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@epfNo", empEpfNo);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int HRIS_No_Acting_Person_Update(string empEpfNo)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[HRIS_No_Acting_Person_Update]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@EpfNo", empEpfNo);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int UpdateCEFTS_BatchGenerated(DataTable batchIDs, object BankCode, object UserID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[UpdateCEFTS_BatchGenerated]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@batchIDs", batchIDs);
        cmd.Parameters.AddWithValue("@BankCode", BankCode);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int insertReimbursementRequest(string userID, string narration, double amount)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[Other_insertReimbursementRequest]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@narration", narration);
        cmd.Parameters.AddWithValue("@amount", amount);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int CEFTSupdateEmpDetails(string epfNo, string empName, string acNo, string acModule, string swoftCode)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[CEFTS_Update_Emp_Details]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@epfNo", epfNo);
        cmd.Parameters.AddWithValue("@empName", empName);
        cmd.Parameters.AddWithValue("@acNo", acNo);
        cmd.Parameters.AddWithValue("@acModule", acModule);
        cmd.Parameters.AddWithValue("@swoftCode", swoftCode);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int InsertToAuditTrail(string Module, string narration, string userID, string IPAddress)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[InsertToAuditTrail]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@Module", Module);
        cmd.Parameters.AddWithValue("@narration", narration);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@IPAddress", IPAddress);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int HRISupdateLeave(double annual, double casual, double sick, double shortL, double maternity, string epfNo,
        int year)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);


        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[HRISupdateLeave]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@annual", annual);
        cmd.Parameters.AddWithValue("@casual", casual);
        cmd.Parameters.AddWithValue("@sick", sick);
        cmd.Parameters.AddWithValue("@short", shortL);
        cmd.Parameters.AddWithValue("@maternity", maternity);
        cmd.Parameters.AddWithValue("@epfNo", epfNo);
        cmd.Parameters.AddWithValue("@year", year);

        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }

    public int HRIS_Password_reset(string epfNo)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MIS].[dbo].[HRIS_Password_reset]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.AddWithValue("@epfNo", epfNo);


        var returnValueParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
        returnValueParam.Direction = ParameterDirection.ReturnValue;


        cmd.ExecuteNonQuery();

        var returnValue = Convert.ToInt32(returnValueParam.Value);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        //adapter.Fill(dataTable);

        con.Close();
        return returnValue;
    }


    public DataTable PCSOFT_getMFMemberList(object GroupID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[PCSOFT_getMFMemberList]", con);

        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@GroupID", GroupID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Destinity_MF_Select_LoanType(object isActive)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[Destinity_MF_Select_LoanType]", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@IsActive", isActive);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }

    public DataTable MF_getGroupMembersByMemberID(string MemberID)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[MF_getGroupMembersByMemberID]", con);

        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@MemberID", MemberID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Destinity_MF_Select_Relationship()
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[Destinity_MF_Select_Relationship]", con);

        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;

        //cmd.Parameters.AddWithValue("@MemberID",MemberID);
        //int rowCount = cmd.ExecuteNonQuery();

        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;
    }

    public DataTable Destinity_MF_Select_Occupation(object isActive)
    {
        SqlConnection con;
        con = new SqlConnection(connetionString);
        con.Open();

        SqlCommand cmd;
        cmd = new SqlCommand("[MicroFinance].[dbo].[Destinity_MF_Select_Occupation]", con);
        //cmd.CommandTimeout = 1000;
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@IsActive", isActive);
        var adapter = new SqlDataAdapter(cmd);
        var dataTable = new DataTable();

        // Execute the stored procedure and fill the DataTable
        adapter.Fill(dataTable);

        con.Close();
        return dataTable;


        //con.Close();
        //return rowCount;
    }
}