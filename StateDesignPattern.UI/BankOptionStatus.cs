using System;
namespace StateDesignPattern.UI {
    public sealed class BankOptionStatus : IEquatable<BankOptionStatus> {
        private enum StatusRepresentation {
            Unknown = 0,
            Open,
            Deposit, 
            Withdraw,
            Freeze,
            Verify,
            Close,
            Exit,            
        }

        private StatusRepresentation Representation { get; }

        private BankOptionStatus(StatusRepresentation representation) {
            Representation = representation;
        }

        public static BankOptionStatus Open() => new BankOptionStatus(StatusRepresentation.Open);
        public static BankOptionStatus Unknown() => new BankOptionStatus(StatusRepresentation.Unknown);

        public BankOptionStatus Deposit() => new BankOptionStatus(StatusRepresentation.Deposit);

        public BankOptionStatus Withdraw() => new BankOptionStatus(StatusRepresentation.Withdraw);

        public BankOptionStatus Freeze() => new BankOptionStatus(StatusRepresentation.Freeze);

        public BankOptionStatus Verify() => new BankOptionStatus(StatusRepresentation.Verify);

        public BankOptionStatus Close() => new BankOptionStatus(StatusRepresentation.Close);

        public BankOptionStatus Exit() => new BankOptionStatus(StatusRepresentation.Exit);

        public override int GetHashCode() => (int)Representation;
        public override bool Equals(object obj) => Equals(obj as BankOptionStatus);
        public bool Equals(BankOptionStatus other) => other != null && Representation == other.Representation;

        public static bool operator ==(BankOptionStatus a, BankOptionStatus b) => 
            ReferenceEquals(a, null) && ReferenceEquals(b, null) ||
            !ReferenceEquals(a, null) && a.Equals(b);

        public static bool operator !=(BankOptionStatus a, BankOptionStatus b) => !(a == b);
    }
}
