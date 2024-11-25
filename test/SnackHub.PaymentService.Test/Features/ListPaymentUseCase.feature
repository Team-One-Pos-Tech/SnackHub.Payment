Feature: List Payment Transactions

    Scenario: List all Accepted payment transactions
        Given a valid transaction table
          | Id                                   | OrderId                              | ClientId                             | Amount | Status   |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 30.00  | Accepted |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac7 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 13.45  | Rejected |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac8 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 22.55  | Approved |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac9 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 17.70  | Accepted |
        When listing all transaction with status 'Accepted' the result list should have '2' elements


    Scenario: List all Rejected payment transactions
        Given a valid transaction table
          | Id                                   | OrderId                              | ClientId                             | Amount | Status   |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 30.00  | Accepted |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac7 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 13.45  | Rejected |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac8 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 22.55  | Approved |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac9 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 17.70  | Accepted |
        When listing all transaction with status 'Rejected' the result list should have '1' elements

    Scenario: List all Approved payment transactions
        Given a valid transaction table
          | Id                                   | OrderId                              | ClientId                             | Amount | Status   |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 30.00  | Approved |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac7 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 13.45  | Approved |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac8 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 22.55  | Approved |
          | 93eccf34-14e5-4c85-bb11-631d523e3ac9 | 93eccf34-14e5-4c85-bb11-631d523e3ac6 | 93eccf34-14e5-4c85-bb11-631d523e3ad1 | 17.70  | Accepted |
        When listing all transaction with status 'Approved' the result list should have '3' elements