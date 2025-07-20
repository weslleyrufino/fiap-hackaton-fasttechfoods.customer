USE FastTechFoodsCustomer

GO

INSERT INTO Customers ( Name, Email, CPF, PasswordHash, CreatedAt)
VALUES 
(
    'Joselito',
    'joselito@yahoo.com.br',
    '69036452090',
    '$2a$12$tMWmu7KGMJslUHcaLv4nqOGowww3NYbwa61h.p9FohgHOU75VWEIe',
    GETDATE()
),
(
    'Maria',
    'maria@hotmail.com',
    '07187176007',
    '$2a$12$zIxyDCEsyx5vq6Za/Wll2.gx91/GKSnQoXYZ0nY0sMimQd.bYuiCq',
    GETDATE()
);