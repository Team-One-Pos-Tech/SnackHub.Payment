Feature: Payment Transactions Management

    Scenario: Valid payment request submmited to Approve a Transaction
        Given a client with id '93eccf34-14e5-4c85-bb11-631d523e3ad1' and name 'John Doe' and CPF '98430490043'
        And a payment transaction table
          | Id                                   | OrderId                              | ClientId                             | Amount |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 30.00  |
        When submitting an approve payment request for transaction id '93eccf34-14e5-4c85-bb11-631d523e3ac6'
        Then the transaction with id '93eccf34-14e5-4c85-bb11-631d523e3ac6' should have status 'Approved'
        And should rise the event PaymentStatusUpdated with status 'Approved'

    Scenario: Valid payment request submmited to Reject a Transaction
        Given a client with id '93eccf34-14e5-4c85-bb11-631d523e3ad1' and name 'John Doe' and CPF '98430490043'
        And a payment transaction table
          | Id                                   | OrderId                              | ClientId                             | Amount |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 30.00  |
        When submitting a reject payment request for transaction id '93eccf34-14e5-4c85-bb11-631d523e3ac6'
        Then the transaction with id '93eccf34-14e5-4c85-bb11-631d523e3ac6' should have status 'Rejected'
        And should rise the event PaymentStatusUpdated with status 'Rejected'