IF NOT EXISTS(SELECT 1 FROM sys.schemas WHERE name = 'acc')
    EXEC ('CREATE SCHEMA acc');
GO;

IF NOT EXISTS(SELECT 1 FROM sys.schemas WHERE name = 'car')
    EXEC ('CREATE SCHEMA car');
GO;

DROP TABLE IF EXISTS car.cards;
DROP TABLE IF EXISTS acc.accounts;

CREATE TABLE acc.accounts (
    account_id                  UNIQUEIDENTIFIER NOT NULL,
    account_code                VARCHAR(20) NOT NULL,
    iban                        VARCHAR(24) NOT NULL,
    
    -- pk --
    CONSTRAINT pk_accounts PRIMARY KEY CLUSTERED (account_id)
);

CREATE TABLE car.cards (
    card_id                     UNIQUEIDENTIFIER NOT NULL,
    holder_name                 VARCHAR(50) NOT NULL,
    pan                         VARCHAR(16) NOT NULL,
    expiry_date                 DATE NOT NULL,
    account_id                  UNIQUEIDENTIFIER,

    -- pk --
    CONSTRAINT pk_cards PRIMARY KEY CLUSTERED (card_id),
    -- fk --
    CONSTRAINT fk_cards_accounts FOREIGN KEY (account_id) REFERENCES acc.accounts (account_id)
);