import { Modal as MantineModal } from '@mantine/core';

type ModalProps = {
  opened: boolean;
  onClose: () => void;
  header: React.ReactNode;
  body: React.ReactNode;
};

export default function Modal({ opened, onClose, header, body }: ModalProps) {
  return (
    <MantineModal.Root opened={opened} onClose={onClose}>
      <MantineModal.Overlay />
      <MantineModal.Content>
        <MantineModal.Header>
          <MantineModal.Title>{header}</MantineModal.Title>
          <MantineModal.CloseButton />
        </MantineModal.Header>
        <MantineModal.Body>{body}</MantineModal.Body>
      </MantineModal.Content>
    </MantineModal.Root>
  );
}
