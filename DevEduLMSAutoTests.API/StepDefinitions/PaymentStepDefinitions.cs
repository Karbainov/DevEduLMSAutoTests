
namespace DevEduLMSAutoTests.API.StepDefinitions
{

    [Binding]
    public class PaymentStepDefinitions
    {
        private string _managerToken;
        private int _userId;
        private AuthenticationClient _authenticationClient;
        private AddPaymentToUserResponse _userPayment;
        private PaymentClient _paymentClient;
        private UpdatePaymentRequest _newPayment;
        private AddPaymentToUserResponse _updatedPayment;

        [Given(@"register as user")]
        public void GivenRegisterAsUser(Table table)
        {
            List<RegisterRequest> registerRequests = table.CreateSet<RegisterRequest>().ToList();
            RegisterRequest registerRequest = registerRequests[0];
            _authenticationClient = new AuthenticationClient();
            _userId = _authenticationClient.RegisterUser(registerRequest).Id;
        }

        [Given(@"authorize as manager")]
        public void GivenAuthorizeAsAManager(Table table)
        {
            List<SignInRequest> signInRequests = table.CreateSet<SignInRequest>().ToList();
            SignInRequest managerSignInRequest = signInRequests[0];
            _managerToken = _authenticationClient.AuthorizeUser(managerSignInRequest);
        }

        [Given(@"manager add payment to student user")]
        public void GivenManagerAddPaymentToUser(Table table)
        {
            AddPaymentToUserRequest newPayment = new AddPaymentToUserRequest()
            {
                Date = table.CreateInstance<AddPaymentToUserRequest>().Date,
                Sum = table.CreateInstance<AddPaymentToUserRequest>().Sum,
                UserId = _userId,
                IsPaid = table.CreateInstance<AddPaymentToUserRequest>().IsPaid
            };
            _userPayment = _paymentClient.AddPaymentByManager(newPayment, _managerToken);
            throw new PendingStepException();
        }

        [Given(@"manager can see this payment")]
        public void GivenManagerCanSeeThisPayment()
        {
            List<AddPaymentToUserResponse> listOfPayments = _paymentClient.GetPaymentsByUserId(_userId, _managerToken);
            CollectionAssert.Contains(listOfPayments, _userPayment);
        }

        [Given(@"manager updates this payment")]
        public void GivenManagerUpdateThisPayment(Table table)
        {
            int paymentId = _userPayment.Id;
            _newPayment = table.CreateInstance<UpdatePaymentRequest>();
            _updatedPayment = _paymentClient.UpdatePayment(_newPayment, paymentId, _managerToken);
        }

        [Given(@"manager can see the updated payment")]
        public void GivenManagerCanSeeTheUpdatedPayment()
        {
            List<AddPaymentToUserResponse> listOfPayments = _paymentClient.GetPaymentsByUserId(_userId, _managerToken);
            CollectionAssert.Contains(listOfPayments, _updatedPayment);
        }

        [Given(@"manager delete this payment")]
        public void GivenManagerDeleteThisPayment()
        {
            HttpStatusCode expectedCode = HttpStatusCode.NoContent;
            _paymentClient.DeletePaymentById(_userId, _managerToken, expectedCode);
        }

        [Given(@"manager can see that the payment deleted")]
        public void GivenManagerCanSeeThatThePaymentDeleted()
        {
            List<AddPaymentToUserResponse> listOfPayments = _paymentClient.GetPaymentsByUserId(_userId, _managerToken);
            CollectionAssert.DoesNotContain(listOfPayments, _updatedPayment);
        }

    }
}
